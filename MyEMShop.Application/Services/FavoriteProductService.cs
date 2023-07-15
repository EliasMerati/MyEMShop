using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Product;

namespace MyEMShop.Application.Services
{
    public class FavoriteProductService : IFavoriteProductService
    {
        #region Injection
        private readonly DatabaseContext _db;
        public FavoriteProductService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddToFavorites(int userId, int productId)
        {
            var product = _db.Products.Find(productId);
            FavoriteProducts favorite = new FavoriteProducts()
            {
                UserId = userId,
                //ProductId=productId,
                Product = product
            };
            _db.FavoriteProducts.Add(favorite);
            _db.SaveChanges();
        }
    }
}
