using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductLevel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        public int PL_Id { get; set; }

        #region Navigation Property
        public Product Product { get; set; }
        public Level Level { get; set; }
        #endregion
    }
}
