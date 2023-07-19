using MyEMShop.Data.Dtos.OrderState;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Order
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }
        public int OrderSum { get; set; }
        public bool IsFinally { get; set; }
        //public string OrderAddress { get; set; }

        public OrderState  OrderState { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }

        #region Relations
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public User.User User { get; set; }
        #endregion
    }
}
