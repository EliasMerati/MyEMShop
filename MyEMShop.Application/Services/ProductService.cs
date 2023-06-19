using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
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

        public int AddProduct(Product product)
        {
            _db.Add(product);
            _db.SaveChanges();
            return product.ProductId;
        }

        public void CreateProduct(List<IFormFile> images, Product product, IFormFile Demo, List<string> colors)
        {
            SetMultiColorForProduct(colors, product);

            SetMultiImageForProduct(images, product);

            SaveDemoForProduct(Demo, product);

            _db.SaveChangesAsync();
        }

        public void SaveDemoForProduct(IFormFile Demo, Product product)
        {
            int productid = AddProduct(product);
            if (Demo is not null)
            {
                var DemoExtension = Path.GetExtension(Demo.FileName);
                var DemoFileName = GenerateCode.GenerateUniqueCode() + DemoExtension;
                var DemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Demos/", DemoFileName);
                using (var filesStream = new FileStream(Path.Combine(DemoPath), FileMode.Create))
                {
                    Demo.CopyTo(filesStream);
                }
                var productnew = _db.Products.First(p => p.ProductId == productid);
                productnew.ProductDemo = DemoFileName;
                _db.Update(productnew);
            }
        }

        public void SetMultiColorForProduct(List<string> colors, Product product)
        {
            int productid = AddProduct(product);
            foreach (var item in colors)
            {
                _db.Colors.Add(new Color { ProductId = productid, PC_Name = item });
            }
        }

        public void SetMultiImageForProduct(List<IFormFile> images, Product product)
        {
            int productid = AddProduct(product);
            if (images.Count > 0)
            {
                foreach (var item in images)
                {
                    if (item.IsImage())
                    {
                        string uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Image/");
                        string output = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Thumbnail/");
                        var extension = Path.GetExtension(item.FileName);
                        var dynamicFileName = GenerateCode.GenerateUniqueCode() + extension;
                        using (var filesStream = new FileStream(Path.Combine(uploads, dynamicFileName), FileMode.Create))
                        {
                            item.CopyTo(filesStream);
                        }

                        #region Resize Image To 150px
                        //ImageConvertor resizer = new ImageConvertor();
                        //resizer.Image_resize(uploads, output, 150);
                        #endregion

                        _db.ProductImages.Add(new ProductImage { ProductId = productid, PI_ImageName = dynamicFileName });
                        _db.SaveChanges();
                    }

                }

            }
            else
            {
                _db.ProductImages.Add(new ProductImage { ProductId = productid, PI_ImageName = "Default.jpg" });
                _db.SaveChanges();
            }
        }

        public IEnumerable<GetProductForAdminDto> GetProducts()
        {
            return _db.Products
                .Select(p=> new GetProductForAdminDto
            {
                ProductId= p.ProductId,
                Productmark= p.Productmark,
                ProductPrice= p.ProductPrice,
                ProductTitle = p.ProductTitle,
            }).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Find(productId);
        }
    }
}
