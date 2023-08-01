using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Dtos.OrderState;
using MyEMShop.Data.Entities.Order;
using MyEMShop.Data.Entities.Product;
using MyEMShop.Data.Entities.User;
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
        private readonly ITaxService _taxService;
        public OrderService(DatabaseContext db
            , IUserPannelService userPannel
            , IProductService productService
            , IUserWalletService userWallet
            , ITaxService taxService)
        {
            _db = db;
            _userPannel = userPannel;
            _productService = productService;
            _userWallet = userWallet;
            _taxService = taxService;
        }
        #endregion



        public int AddOrder(string userName, int productId)
        {
            var user = _userPannel.GetUserByUserName(userName);
            Order order = _db.Orders.FirstOrDefault(o => o.UserId == user.UserId && !o.IsFinally);
            var product = _productService.GetProductById(productId);

            if (order is null)
            {
                if (product.Save != 0)
                {
                    order = new Order()
                    {
                        OrderDate = DateTime.Now,
                        OrderAddress = user.Address,
                        OrderCity = user.City,
                        OrderOstan = user.Ostan,
                        OrderSum = product.ProductPrice - (product.ProductPrice * product.Save / 100),
                        OrderPhoneNumber = user.PhoneNumber,
                        OrderPostalCode = user.PostalCode,
                        UserId = user.UserId,
                        IsFinally = false,


                        OrderState = OrderState.IsProgress,
                        OrderDetails = new List<OrderDetail>()
                    {
                        new OrderDetail()
                        {
                            Count = 1,
                            Price= product.ProductPrice - (product.ProductPrice * product.Save / 100),
                            ProductId= productId,
                        }
                    }
                    };

                }
                else
                {
                    order = new Order()
                    {
                        OrderDate = DateTime.Now,
                        OrderAddress = user.Address,
                        OrderCity = user.City,
                        OrderOstan = user.Ostan,
                        OrderSum = product.ProductPrice,
                        OrderPhoneNumber = user.PhoneNumber,
                        OrderPostalCode = user.PostalCode,
                        UserId = user.UserId,
                        IsFinally = false,


                        OrderState = OrderState.IsProgress,
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

                }

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

                }
                else
                {
                    if (product.Save != 0)
                    {
                        detail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            Price = product.ProductPrice - (product.ProductPrice * product.Save / 100),
                            ProductId = productId,
                        };
                    }
                    else
                    {
                        detail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            Price = product.ProductPrice - (product.ProductPrice * product.Save / 100),
                            ProductId = productId,
                        };
                    }

                    _db.Add(detail);

                }
                _db.SaveChanges();
                UpdatePriceOrder(order.OrderId);
            }

            return order.OrderId;
        }

        public void ChangeStateToIsReady(int orderId)
        {
            try
            {
                var order = GetOrderById(orderId);
                order.OrderState = OrderState.IsReady;
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void ChangeStateToIsSend(int orderId)
        {
            try
            {
                var order = GetOrderById(orderId);
                order.OrderState = OrderState.IsSend;
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }

        }

        public void ChangeStateToIsCancelled(int orderId)
        {
            try
            {
                var order = GetOrderById(orderId);
                order.OrderState = OrderState.IsCanceled;
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }

        }

        public void DeleteFromOrder(int orderId, int productid)
        {
            try
            {
                int products = _db.OrderDetails.Count(o => o.OrderId == orderId);
                var product = _db.OrderDetails.SingleOrDefault(o => o.OrderId == orderId && o.ProductId == productid);
                if (products <= 1)
                {
                    var order = _db.Orders.Find(orderId);
                    var orderdetails = _db.OrderDetails.Where(o => o.OrderId == orderId && o.ProductId == productid).ToList();
                    foreach (var item in orderdetails)
                    {
                        _db.OrderDetails.Remove(item);
                    }
                    _db.Orders.Remove(order);
                    _db.SaveChanges();
                }
                else
                {
                    var order = _db.Orders.Find(orderId);
                    var minus = product.Count * product.Price;
                    order.OrderSum -= minus;
                    _db.OrderDetails.Remove(product);
                    _db.Orders.Update(order);
                    _db.SaveChanges();
                }
                UpdatePriceOrder(orderId);
            }
            catch (Exception)
            {

            }


        }

        public void DeleteOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            var orderdetail = _db.OrderDetails.Where(o => o.OrderId == orderId).ToList();
            foreach (var item in orderdetail)
            {
                _db.OrderDetails.Remove(item);
                _db.SaveChanges();
            }
            _db.Orders.Remove(order);
            _db.SaveChanges();
        }

        public bool FinallyOrder(string userName, int orderId)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);
            var order = _db.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
            int sum = 0;
            foreach (var item in order.OrderDetails)
            {
                sum = item.Price * item.Count;
            }
            int tax = (int)_taxService.GetTax().TaxValue;
            int taxvalue = sum * tax / 100;
            int total = sum + taxvalue;

            if (order is null || order.IsFinally) { return false; }

            if (_userPannel.BalanceWallet(userName) >= order.OrderSum)
            {
                order.IsFinally = true;
                order.OrderSum = total;
                _userWallet.AddWallet(new Wallet()
                {
                    Amount = order.OrderSum,
                    CreateDate = DateTime.Now,
                    Description = "فاکتور شماره ی #" + order.OrderId,
                    IsPay = true,
                    UserId = userId,
                    TypeId = 2,
                });
                _db.Update(order);
                _db.SaveChanges();
                return true;
            }

            return false;
        }

        public Order GetOrderById(int orderId)
        {
            return _db.Orders.Find(orderId);
        }

        public Order GetOrderForUserPannel(string userName, int orderId)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);
            return _db.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }

        public List<OrdersDto> GetOrdersForAdmin(OrderState orderState)
        {
            return _db.Orders
                .Include(o => o.OrderDetails)
                .Include(u => u.User)
                .Where(os => os.OrderState == orderState)
                .OrderBy(o => o.OrderDate)
                .Select(o => new OrdersDto
                {
                    OrderId = o.OrderId,
                    OrderState = o.OrderState,
                    InsertTime = o.OrderDate,
                    ProductCount = o.OrderDetails.Count,
                    UserId = o.UserId,
                    OrderAddress = o.OrderOstan + "-" + o.OrderCity + "-" + o.OrderAddress + "-" + "کد پستی :" + o.OrderPostalCode + "-" + "به نام:" + o.User.Name + " " + o.User.Family,
                }).ToList();
        }

        public List<Order> GetUserOrders(string userName)
        {
            int userId = _userPannel.GetUserIdByUserName(userName);

            return _db.Orders.Where(o => o.UserId == userId).ToList();


        }

        public bool IsOrderExist(int orderId)
        {
            return _db.Orders.Any(o => o.OrderId == orderId);
        }

        public Order OrderNotPayment()
        {
            return _db.Orders.SingleOrDefault(o => !o.IsFinally);
        }

        public void Refresh(int quantity, int orderId, int productId)
        {
            try
            {
                var details = _db.OrderDetails.Where(o => o.ProductId == productId).ToList();
                foreach (var item in details)
                {
                    item.Count = quantity;
                    _db.Update(item);
                    _db.SaveChanges();
                }

                UpdatePriceOrder(orderId);
            }
            catch (Exception)
            {
            }

        }

        public Order ShowOrderForAdmin(int orderId, int userId)
        {
            return _db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(p => p.Product)
                .FirstOrDefault(o => o.UserId == userId && o.OrderId == orderId);
        }

        public void UpdateOrder(Order order)
        {
            _db.Orders.Update(order);
            _db.SaveChanges();
        }

        public void UpdatePriceOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            int tax = (int)_taxService.GetTax().TaxValue;
            int taxvalue = order.OrderSum * tax / 100;
            order.OrderSum += taxvalue;
            _db.Update(order);
            _db.SaveChanges();
        }

    }
}
