using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEMShop.Data.Entities.Product
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "گروه")]
        public int GroupId { get; set; }

        [Display(Name = "گروه فرعی")]
        public int? SubGroup { get; set; }

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

        [Display(Name = "جنس محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200)]
        public string Productmark { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string ProductPrice { get; set; }

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

        [Display(Name = "فیلم محصول")]
        [MaxLength(200)]
        public string ProductDemo { get; set; }




        #region Navigation Property
        [ForeignKey(nameof(GroupId))]
        public ProductGroup productGroup { get; set; }

        [ForeignKey(nameof(SubGroup))]
        public ProductGroup GroupSub { get; set; }
        public ICollection<ProductLevel> ProductLevels { get; set; }
        public ICollection<ProductColor> ProductColors { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
        public ICollection<ProductSize> ProductSizes { get; set; }
        #endregion
    }
}
