using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IProductService
    {
        IList<ProductGroup> GetGroups();
        IList<SelectListItem> GetGroupsForManageProduct();
        IList<SelectListItem> GetSubGroupsForManageProduct(int groupId);

        IList<SelectListItem> GetProductLevel();
        IList<SelectListItem> GetProductSize();
    }
}
