using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IProductService
    {

        #region Product
        Tuple<List<GetProductForAdminDto>, int> GetProducts(int pageId = 1);
        int AddProduct(Product product);
        IList<SelectListItem> GetProductLevel();
        IList<SelectListItem> GetProductSize();
        Product GetProductByProductId(int productId);
        void CreateProduct(List<IFormFile> images,Product product, IFormFile Demo, IFormFile Image, string color);
        void AddColorForProduct(string color , Product product);
        void SetMainImageForProduct(Product product, IFormFile Image);
        void SaveDemoForProduct(IFormFile Demo, Product product);
        void SetMultiColorForProduct(List<string> colors, Product product);
        void SetMultiImageForProduct(List<IFormFile> images, Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product, IFormFile Demo, IFormFile Image);
        Tuple<List<ShowProductForIndex>,int> ShowProduct(int pageid =1 , string Filter = "",List<int> selectedgroup = null , string orderbytype = "all",int take = 0);
        Product GetProductForShow(int productId);
        void DeleteProduct(Product product);
        List<Product> GetPopularProduct();
        List<Product> GetSpecialProduct();
        List<Product> GetLatestProduct();
        List<Product> GetPopularProductForIndex();
        List<Product> GetSpecialProductForIndex();
        List<Product> GetAllProductLikeName(int productId);
        #endregion

    }
}
