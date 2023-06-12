using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class Color
    {
        [Key]
        public int PC_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PC_Name { get; set; }

        #region Navigation Property
        public ICollection<ProductColor> ProductColors { get; set; }
        #endregion
    }
}
