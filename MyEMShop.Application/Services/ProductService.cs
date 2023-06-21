using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using static System.Net.Mime.MediaTypeNames;
using Image = SixLabors.ImageSharp.Image;
using ImageProcessor.Imaging.Helpers;

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
            product.InsertDate= DateTime.Now;
            SetMultiColorForProduct(colors, product);

            SetMultiImageForProduct(images, product);

            SaveDemoForProduct(Demo, product);

            _db.SaveChangesAsync();
        }

        public void SaveDemoForProduct(IFormFile Demo, Product product)
        {
            
            if (Demo is not null)
            {
                var DemoExtension = Path.GetExtension(Demo.FileName);
                var DemoFileName = GenerateCode.GenerateUniqueCode() + DemoExtension;
                var DemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Demos/", DemoFileName);
                using (var filesStream = new FileStream(Path.Combine(DemoPath), FileMode.Create))
                {
                    Demo.CopyTo(filesStream);
                }
                var productnew = _db.Products.First(p => p.ProductId == product.ProductId);
                productnew.ProductDemo = DemoFileName;
                _db.Update(productnew);
            }
        }

        public void SetMultiColorForProduct(List<string> colors, Product product)
        {
            
            foreach (var item in colors)
            {
                _db.Colors.Add(new Data.Entities.Product.Color { ProductId = product.ProductId, PC_Name = item });
            }
        }

        public void SetMultiImageForProduct(List<IFormFile> images, Product product)
        {
            int priductid = AddProduct(product);
            if (images.Count > 0)
            {
                foreach (var item in images)
                {
                    if (item.IsImage())
                    {
                        string uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Image/");
                        
                        var extension = Path.GetExtension(item.FileName);
                        var dynamicFileName = GenerateCode.GenerateUniqueCode() + extension;
                        using (var filesStream = new FileStream(Path.Combine(uploads, dynamicFileName), FileMode.Create))
                        {
                            item.CopyTo(filesStream);
                        }
                        _db.ProductImages.Add(new ProductImage { ProductId = priductid, PI_ImageName = dynamicFileName });
                        _db.SaveChanges();
                    }

                }
                #region Resize Image For Thumbnail
                string MainImages = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Image/");
                IEnumerable<string> Images = Directory.EnumerateFiles(MainImages);
                foreach (string file in Images)
                {
                    string output = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Thumbnail/"
                        ,Path.GetFileNameWithoutExtension(file)
                    + "_Thumb" + Path.GetExtension(file));
                    
                    using (Image image = Image.Load(file))
                    {
                        image.Mutate(x => x.Resize(220, 330));
                        image.Save(output);
                    }
                }
                #endregion
                _db.SaveChanges();
            }
            else
            {
                _db.ProductImages.Add(new ProductImage { ProductId = priductid, PI_ImageName = "Default.jpg" });
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

        public void UpdateProduct(Product product, IFormFile Demo)
        {
            product.UpdateTime = DateTime.Now;

            #region UpdateDemo
            if (Demo is not null)
            {
                if (product.ProductDemo is not null)
                {
                    var DeleteDemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Demos/", product.ProductDemo);
                    if (File.Exists(DeleteDemoPath))
                    {
                        File.Delete(DeleteDemoPath);
                    }
                }
                var DemoExtension = Path.GetExtension(Demo.FileName);
                var DemoFileName = GenerateCode.GenerateUniqueCode() + DemoExtension;
                var DemoPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/Demos/", DemoFileName);
                using (var filesStream = new FileStream(Path.Combine(DemoPath), FileMode.Create))
                {
                    Demo.CopyTo(filesStream);
                }
                product.ProductDemo = DemoFileName;
            }
            #endregion

            _db.Update(product);
            _db.SaveChanges();
        }
    }
}
