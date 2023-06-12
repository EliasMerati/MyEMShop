using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IGroupService
    {
        IList<ProductGroup> GetGroups();
    }
}
