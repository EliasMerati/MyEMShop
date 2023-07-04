using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Entities.Order;
using MyEMShop.Data.Entities.Wallet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Injection
        private readonly DatabaseContext _db;
        private readonly IUserPannelService _userPannel;
        private readonly IProductService _productService;
        private readonly IUserWalletService _userWallet;
        public OrderService(DatabaseContext db
            , IUserPannelService userPannel
            , IProductService productService
            , IUserWalletService userWallet)
        {
            _db = db;
            _userPannel = userPannel;
            _productService = productService;
            _userWallet = userWallet;
        }


        #endregion

        public void AddDiscount(Discount discount)
        {
            _db.Add(discount);
            _db.SaveChanges();
        }

        public int AddOrder(string userName, int productId)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);
            var order = _db.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinally);
            var product = _productService.GetProductById(productId);
            if (order is null)
            {
                order = new Order()
                {
                    OrderDate = DateTime.Now,
                    UserId = userId,
                    IsFinally = false,
                    OrderSum = product.ProductPrice,
                    OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            Count = 1,
                            Price= product.ProductPrice,
                            ProductId= productId,

                        }
                    }
                };
                _db.Add(order);
                _db.SaveChanges();
            }
            else
            {
                var detail = _db.OrderDetails
                     .FirstOrDefault(d => d.OrderId == order.OrderId && d.ProductId == productId);
                if (detail is not null)
                {
                    detail.Count += 1;
                    _db.OrderDetails.Update(detail);
                    _db.SaveChanges();
                }
                else
                {
                    detail = new OrderDetail()
                    {
                        OrderId = order.OrderId,
                        Count = 1,
                        Price = product.ProductPrice,
                        ProductId = productId,
                    };
                    _db.Add(detail);
                    _db.SaveChanges();
                }
                UpdatePriceOrder(order.OrderId);
            }
            
            return order.OrderId;
        }

        public bool FinallyOrder(string userName, int orderId)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);

            var order = _db.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);

            if (order is null || order.IsFinally) { return false; }

            if(_userPannel.BalanceWallet(userName) >= order.OrderSum)
            {
                order.IsFinally = true;
                _userWallet.AddWallet(new Wallet()
                {
                    Amount= order.OrderSum,
                    CreateDate = DateTime.Now,
                    Description = "فاکتور شماره ی #" +order.OrderId,
                    IsPay=true,
                    UserId =userId,
                    TypeId = 2,
                });
                _db.Update(order);
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        public Discount GetDiscount(string code)
        {
            return _db.Discounts.SingleOrDefault(d => d.DiscountCode == code);
        }

        public Discount GetDiscountById(int discountId)
        {
            return _db.Discounts.Find(discountId);
        }

        public List<Discount> GetDiscounts()
        {
            return _db.Discounts.ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _db.Orders.Find(orderId);
        }

        public Order GetOrderForUserPannel(string userName, int orderId)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);
            return _db.Orders.Include(o=> o.OrderDetails).ThenInclude(od=> od.Product)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }

        public IList<Order> GetUserOrders(string userName)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);
            return _db.Orders.Where(o => o.UserId == userId).ToList();
        }

        public void UpdateDiscount(Discount discount)
        {
            _db.Update(discount);
            _db.SaveChanges();
        }

        public void UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }

        public void UpdatePriceOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            order.OrderSum = _db.OrderDetails.Where(o => o.OrderId == order.OrderId).Sum(d => d.Price);
            _db.Update(order);
            _db.SaveChanges();
        }

        public DiscountUseType UseDiscount(int orderId, string code)
        {
            var discount = GetDiscount(code);

            if (discount is null) { return DiscountUseType.NotFound; }

            if (discount.StartDate != null && discount.StartDate< DateTime.Now) { return DiscountUseType.ExpireDate; }

            if (discount.EndDate != null && discount.EndDate >= DateTime.Now) { return DiscountUseType.ExpireDate; }

            if (discount.UsableCount != null && discount.UsableCount < 1) { return DiscountUseType.Finished; }

            var order = GetOrderById(orderId);

            if (_db.UserDiscountCodes.Any(d=> d.UserId == order.UserId && d.DiscountId == discount.DiscountId)) { return DiscountUseType.UserUsed; }

            int percent = (order.OrderSum * discount.DiscountPercent) / 100;
            order.OrderSum = order.OrderSum - percent;
            _db.Update(order);

            if (discount.UsableCount != null)
            {
                discount.UsableCount -= 1;
            }
            _db.Discounts.Update(discount);

            _db.UserDiscountCodes.Add(new Data.Entities.User.UserDiscountCode
            {
                DiscountId= discount.DiscountId,
                UserId= order.UserId,
            });

            _db.SaveChanges();

            return DiscountUseType.Success;
        }
    }
}
