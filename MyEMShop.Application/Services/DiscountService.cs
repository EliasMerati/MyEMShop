using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class DiscountService : IDiscountService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        private readonly IOrderService _orderService;
        public DiscountService(DatabaseContext db, IOrderService orderService)
        {
            _db = db;
            _orderService = orderService;
        }
        #endregion

        public void AddDiscount(Discount discount)
        {
            _db.Add(discount);
            _db.SaveChanges();
        }

        public DiscountUseType UseDiscount(int orderId, string code)
        {
            var discount = GetDiscount(code);

            if (discount is null) { return DiscountUseType.NotFound; }

            if (discount.StartDate != null && discount.StartDate < DateTime.Now) { return DiscountUseType.ExpireDate; }

            if (discount.EndDate != null && discount.EndDate >= DateTime.Now) { return DiscountUseType.ExpireDate; }

            if (discount.UsableCount != null && discount.UsableCount < 1) { return DiscountUseType.Finished; }

            var order = _orderService.GetOrderById(orderId);

            if (_db.UserDiscountCodes.Any(d => d.UserId == order.UserId && d.DiscountId == discount.DiscountId)) { return DiscountUseType.UserUsed; }

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
                DiscountId = discount.DiscountId,
                UserId = order.UserId,
            });

            _db.SaveChanges();

            return DiscountUseType.Success;
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

        public bool IsExistCode(string code)
        {
            return _db.Discounts.Any(d => d.DiscountCode == code);
        }

        public void UpdateDiscount(Discount discount)
        {
            _db.Update(discount);
            _db.SaveChanges();
        }
    }
}
