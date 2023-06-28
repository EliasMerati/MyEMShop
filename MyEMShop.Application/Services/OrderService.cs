using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class OrderService : IOrderService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        private readonly IUserPannelService _userPannel;
        private readonly IProductService _productService;
        public OrderService(DatabaseContext db, IUserPannelService userPannel, IProductService productService)
        {
            _db = db;
            _userPannel = userPannel;
            _productService = productService;
        }
        #endregion


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

        public void UpdatePriceOrder(int orderId)
        {
            var order = _db.Orders.Find(orderId);
            order.OrderSum = _db.OrderDetails.Where(o => o.OrderId == order.OrderId).Sum(d => d.Price);
            _db.Update(order);
            _db.SaveChanges();
        }
    }
}
