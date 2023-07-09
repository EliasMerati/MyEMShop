using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IGroupService
    {
        List<ProductGroup> GetGroups();
        IList<SelectListItem> GetGroupsForManageProduct();
        IList<SelectListItem> GetSubGroupsForManageProduct(int groupId);
        void AddGroup(ProductGroup group);
        void UpdateGroup(ProductGroup group);
    }
}
