using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IFavoriteProductService
    {
        void AddToFavorites(int userId , int productId);
        List<ShowMyFavoriteProductDto> ShowMyFavorite(int userId);
        void DeleteFromFavorites(int productId);
    }
}
