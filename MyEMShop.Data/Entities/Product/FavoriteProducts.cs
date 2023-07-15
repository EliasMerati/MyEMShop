using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class FavoriteProducts
    {
        [Key]
        public int FP_Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        #region Relations
        public Product Product { get; set; }
        #endregion
    }
}
