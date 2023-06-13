using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Application.Services
{
    public class ProductService : IProductService
    {
        #region Inject Context
        private readonly DatabaseContext _db;
        public ProductService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public IList<ProductGroup> GetGroups()
        {
            return _db.ProductGroups.ToList();
        }

        public IList<SelectListItem> GetGroupsForManageProduct()
        {
            return _db.ProductGroups
                .Where(p => p.ParentId == null)
                .Select(p => new SelectListItem
                {
                    Value = p.GroupId.ToString(),
                    Text = p.GroupTitle
                })
                .ToList();
        }

        public IList<SelectListItem> GetSubGroupsForManageProduct(int groupId)
        {
            return _db.ProductGroups
                .Where(p => p.ParentId == groupId)
                .Select(p => new SelectListItem
                {
                    Value = p.GroupId.ToString(),
                    Text = p.GroupTitle
                })
                .ToList();
        }
    }
}
