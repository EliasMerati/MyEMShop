using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductGroup
    {

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

        [InverseProperty("productGroup")]
        public ICollection<Product> Products { get; set; } 

        [InverseProperty("GroupSub")]
        public ICollection<Product> SubGroups { get; set; }

        
        #endregion
    }
}
