using System;

namespace MyEMShop.Data.Dtos.Order
{
    public class OrdersDto
    {
        public int OrderId { get; set; }
        public DateTime InsertTime { get; set; }
        public int UserId { get; set; }
        public OrderState.OrderState OrderState { get; set; }
        public int ProductCount { get; set; }


    }
}
