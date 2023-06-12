using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductGroup
    {
        public ProductGroup()
        {

        }

        [Key]
        public int GroupId { get; set; }

        [Display(Name = "نام گروه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string GroupTitle { get; set; }

        [Display(Name = "حذف شده؟")]
        public bool IsDelete { get; set; }

        [Display(Name = "گروه اصلی")]
        public int? ParentId { get; set; }


        #region Navigation Property
        [ForeignKey(nameof(ParentId))]
        public ICollection<ProductGroup> Groups { get; set; }

        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
