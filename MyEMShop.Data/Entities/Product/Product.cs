using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "وضعیت")]
        public int PL_Id { get; set; }

        [Required]
        [Display(Name = "رنگ")]
        public int PC_Id { get; set; }

        [Required]
        [Display(Name = "عکس")]
        public int PI_Id { get; set; }

        [Required]
        [Display(Name = "سایز")]
        public int PS_Id { get; set; }

        [Display(Name = "نام محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string ProductTitle { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public int ProductPrice { get; set; }

        [Display(Name = "توضیحات محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = "بررسی محصول")]
        public string ProductCheck { get; set; }

        [Display(Name = "تگ ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(600)]
        public string Tags { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }




        #region Navigation Property
        public ProductGroup ProductGroup { get; set; }
        public ICollection<ProductLevel> ProductLevels { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        #endregion
    }
}
