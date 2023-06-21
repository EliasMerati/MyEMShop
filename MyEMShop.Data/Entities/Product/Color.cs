using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class Color
    {
        [Key]
        public int PC_Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        [MaxLength(100)]
        public string PC_Name { get; set; }

        #region Navigation Property
        public ICollection<Product> Products { get; set; }
        #endregion
    }
}
