using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;
using System.Linq;

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
                Product = product
            };
            _db.FavoriteProducts.Add(favorite);
            _db.SaveChanges();
        }

        public void DeleteFromFavorites(int productId)
        {
            var product = _db.FavoriteProducts.Where(p => p.ProductId == productId).Single();
            _db.FavoriteProducts.Remove(product);
            _db.SaveChanges();
        }

        public List<ShowMyFavoriteProductDto> ShowMyFavorite(int userId)
        {
            return _db.Products.
                Include(p => p.FavoriteProducts)
                .Where(p => p.FavoriteProducts.Any(p => p.UserId == userId))
                .OrderByDescending(p => p.ProductId)
                .Select(p => new ShowMyFavoriteProductDto
                {
                    ProductId= p.ProductId,
                    MainImageProduct = p.MainImageProduct,
                    ProductPrice= p.ProductPrice,
                    ProductTitle = p.ProductTitle,
                    Save= p.Save,
                })
                .ToList();
        }
    }
}
