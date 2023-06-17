using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        int AddProduct(Product product);
        void AddProductWithMultipleImage(List<IFormFile> images,Product product, IFormFile Demo);
        #endregion

    }
}
