using System;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Order
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        [Display(Name = "کد تخفیف")]
        [Required]
        [MaxLength(150)]
        public string DiscountCode { get; set; }

        [Display(Name = "درصد تخفیف")]
        [Required]
        public int DiscountPercent { get; set; }

        [Display(Name = "تعداد استفاده کنندگان از تخفیف")]
        public int? UsableCount { get; set; }

        [Display(Name = "تاریخ شروع تخفیف")]
        public DateTime? StartDate { get; set; }

        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? EndDate { get; set; }
    }
}
