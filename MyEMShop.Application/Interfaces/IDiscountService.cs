﻿using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Entities.Order;
using System;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IDiscountService
    {
        Discount GetDiscount(string code);
        DiscountUseType UseDiscount(int orderId, string code);
        void AddDiscount(Discount discount);
        Tuple<List<Discount>, int> GetDiscounts(int pageId =1);
        Discount GetDiscountById(int discountId);
        void UpdateDiscount(Discount discount);
        bool IsExistCode(string code);
    }
}
