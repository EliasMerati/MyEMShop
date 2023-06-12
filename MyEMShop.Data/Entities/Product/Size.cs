using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class Size
    {
        [Key]
        public int PS_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string SizeTitle { get; set; }

        #region Navigation Property
        public ICollection<ProductSize> ProductSizes { get; set; }
        #endregion
    }
}
