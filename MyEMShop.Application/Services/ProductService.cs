using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

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
                    Text = p.GroupTitle,
                })
                .ToList();
        }

        public IList<SelectListItem> GetProductLevel()
        {
            return _db.Levels.Select(l => new SelectListItem()
            {
                Value = l.PL_Id.ToString(),
                Text = l.PL_Title
            }).ToList();
        }

        public IList<SelectListItem> GetProductSize()
        {
            return _db.Sizes.Select(l => new SelectListItem()
            {
                Value = l.PS_Id.ToString(),
                Text = l.SizeTitle
            }).ToList();
        }

        public IList<SelectListItem> GetSubGroupsForManageProduct(int groupId)
        {
            return _db.ProductGroups
                .Where(p => p.ParentId == groupId)
                .Select(p => new SelectListItem
                {
                    Value = p.GroupId.ToString(),
                    Text = p.GroupTitle,
                })
                .ToList();
        }

        public int AddProduct(Product product, IFormFile imageProduct)
        {
            throw new NotImplementedException();
        }

        #region Insert More Image
        //        string webRootPath = _hostingEnvironment.WebRootPath;
        //        var files = HttpContext.Request.Form.Files;

        //           if (files.Count > 0)
        //            {
        //                foreach (var item in files)
        //                 {
        //                   var uploads = Path.Combine(webRootPath, "images");
        //        var extension = Path.GetExtension(item.FileName);
        //        var dynamicFileName = Guid.NewGuid().ToString() + "_" + ProductVM.Product.Id + extension;

        //                     using (var filesStream = new FileStream(Path.Combine(uploads, dynamicFileName), FileMode.Create))
        //                   {
        //                      item.CopyTo(filesStream);
        //                    }

        //newproduct.product_Images.Add(new Product_Images { ImageName = dynamicFileName });
        //                }
        //           }
        #endregion
    }
}
