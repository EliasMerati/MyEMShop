using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IProductService
    {
        #region Group
        IList<ProductGroup> GetGroups();
        IList<SelectListItem> GetGroupsForManageProduct();
        IList<SelectListItem> GetSubGroupsForManageProduct(int groupId);
        IList<SelectListItem> GetProductLevel();
        IList<SelectListItem> GetProductSize();
        #endregion

        #region Product
        IEnumerable<GetProductForAdminDto> GetProducts();
        int AddProduct(Product product);
        void CreateProduct(List<IFormFile> images,Product product, IFormFile Demo, IFormFile Image, string color/*, List<string> colors*/);
        void AddColorForProduct(string color , Product product);
        void SetMainImageForProduct(Product product, IFormFile Image);
        void SaveDemoForProduct(IFormFile Demo, Product product);
        void SetMultiColorForProduct(List<string> colors, Product product);
        void SetMultiImageForProduct(List<IFormFile> images, Product product);
        Product GetProductById(int productId);
        void UpdateProduct(Product product, IFormFile Demo, IFormFile Image);
        #endregion

    }
}
