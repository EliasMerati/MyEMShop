using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IFavoriteProductService
    {
        void AddToFavorites(int userId , int productId);
        Tuple<List<ShowMyFavoriteProductDto>, int> ShowMyFavorite(int userId, int pageId = 1);
        void DeleteFromFavorites(int productId);
    }
}
