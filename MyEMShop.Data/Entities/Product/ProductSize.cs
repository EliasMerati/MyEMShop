using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductSize
    {
        [Key]
        public int id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Required]
        public int PS_Id { get; set; }

        #region Navigation Property
        public Product Product { get; set; }
        public Size Size { get; set; }
        #endregion
    }
}
