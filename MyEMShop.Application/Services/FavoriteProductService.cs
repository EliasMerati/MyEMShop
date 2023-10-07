using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System;
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
            var products = _db.FavoriteProducts.Where(p => p.ProductId == productId).ToList();
            foreach (var item in products)
            {
                _db.FavoriteProducts.Remove(item);
            }
            
            _db.SaveChanges();
        }

        public Tuple<List<ShowMyFavoriteProductDto>,int> ShowMyFavorite(int userId , int pageId =1)
        {
            int skip = (pageId - 1) * 4;
            int rowsCount = _db.Products.
                Include(p => p.FavoriteProducts)
                .Where(p => p.FavoriteProducts.Any(p => p.UserId == userId))
                .OrderByDescending(p => p.ProductId)
                .Select(p => new ShowMyFavoriteProductDto
                {
                    ProductId = p.ProductId,
                    MainImageProduct = p.MainImageProduct,
                    ProductPrice = p.ProductPrice,
                    ProductTitle = p.ProductTitle,
                    Save = p.Save,
                }).Count() / 4;

            var result = _db.Products.
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
                .Skip(skip)
                .Take(4)
                .AsNoTracking()
                .ToList();

            return Tuple.Create(result,rowsCount);
        }
    }
}
