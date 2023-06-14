using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductImage
    {
        [Key]
        public int PI_Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string PI_ImageName { get; set; }

        #region Navigation Property
        public Product Product { get; set; }
        #endregion
    }
}
