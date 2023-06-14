using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductColor
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int PC_Id { get; set; }

        #region Navigation property
        public Product Product { get; set; }
        public Color Color { get; set; }
        #endregion
    }
}
