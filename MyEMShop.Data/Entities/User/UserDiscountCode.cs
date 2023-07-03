using MyEMShop.Data.Entities.Order;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.User
{
    public class UserDiscountCode
    {
        [Key]
        public int UserDiscountCodeId { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }

        #region Relations
        public User User { get; set; }
        public Discount Discount { get; set; }
        #endregion
    }
}
