using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.Data.Entities.Product;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Image = SixLabors.ImageSharp.Image;

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

        public void CreateProduct(List<IFormFile> images, Product product, IFormFile Demo, IFormFile Image, string color)
        {
            product.InsertDate = DateTime.Now;

            SetMainImageForProduct(product, Image);

            AddColorForProduct(color, product);

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

                _db.SaveChangesAsync();
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
                .Select(p => new GetProductForAdminDto
                {
                    ProductId = p.ProductId,
                    Productmark = p.Productmark,
                    ProductPrice = p.ProductPrice,
                    ProductTitle = p.ProductTitle,
                    MainImageProduct = p.MainImageProduct,
                }).ToList();
        }

        public Product GetProductById(int productId)
        {
            return _db.Products.Find(productId);
        }

        public void UpdateProduct(Product product, IFormFile Demo, IFormFile ImageSet)
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

            #region UpdatePicture

            if (ImageSet is not null && ImageSet.IsImage())
            {
                //====================================================================================================== Delete Files

                #region Delete Files
                if (product.MainImageProduct != "Default.jpg")
                {
                    string DeleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPic/", product.MainImageProduct);
                    if (File.Exists(DeleteImagePath))
                    {
                        File.Delete(DeleteImagePath);
                    }
                    string DeleteThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPicThumbnail/", product.MainImageProduct);
                    if (File.Exists(DeleteThumbPath))
                    {
                        File.Delete(DeleteThumbPath);
                    }
                    string DeleteMiniPicPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MiniPic/", product.MainImageProduct);
                    if (File.Exists(DeleteMiniPicPath))
                    {
                        File.Delete(DeleteMiniPicPath);
                    }
                }
                #endregion

                //====================================================================================================== Main Pic

                #region Main Pic
                var mainExtension = Path.GetExtension(ImageSet.FileName);
                var MainFileName = GenerateCode.GenerateUniqueCode() + mainExtension;
                var MainPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPic/", MainFileName);
                using (var filesStream = new FileStream(Path.Combine(MainPath), FileMode.Create))
                {
                    ImageSet.CopyTo(filesStream);
                }
                #endregion

                //====================================================================================================== Thumbnail

                #region Thumbnail
                string ThumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPicThumbnail/", MainFileName);

                using (Image image = Image.Load(MainPath))
                {
                    image.Mutate(x => x.Resize(220, 330));
                    image.SaveAsync(ThumbPath);
                }
                #endregion

                //====================================================================================================== Mini Pic

                #region Mini Pic
                string MiniPicPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MiniPic/", product.MainImageProduct);

                using (Image image = Image.Load(MainPath))
                {
                    image.Mutate(x => x.Resize(50, 75));
                    image.SaveAsync(MiniPicPath);
                }
                #endregion

                product.MainImageProduct = MainFileName;
            }

            #endregion

            _db.Update(product);
            _db.SaveChanges();
        }

        public void SetMainImageForProduct(Product product, IFormFile ImageFile)
        {
            if (ImageFile is not null)
            {
                #region Main Pic
                product.MainImageProduct = GenerateCode.GenerateUniqueCode() + Path.GetExtension(ImageFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPic/", product.MainImageProduct);
                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImageFile.CopyTo(stream);
                }
                #endregion

                //=====================================================================================================

                #region thumbnail
                string OutputPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPicThumbnail/", product.MainImageProduct);

                using (Image image = Image.Load(Imagepath))
                {
                    image.Mutate(x => x.Resize(220, 330));
                    image.SaveAsync(OutputPath);
                }
                #endregion

                //=====================================================================================================

                #region Mini Pic
                string MiniPicPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MiniPic/", product.MainImageProduct);

                using (Image image = Image.Load(Imagepath))
                {
                    image.Mutate(x => x.Resize(50, 75));
                    image.SaveAsync(MiniPicPath);
                }
                #endregion
            }
            else
            {
                product.MainImageProduct = "Default.jpg";

                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPic/", product.MainImageProduct);
                string OutputPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MainPicThumbnail/", "Default.jpg");

                using (Image image = Image.Load(Imagepath))
                {
                    image.Mutate(x => x.Resize(220, 330));
                    image.SaveAsync(OutputPath);
                }
                //====================================================================================================================

                string MiniPicPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/MiniPic/", product.MainImageProduct);

                using (Image image = Image.Load(Imagepath))
                {
                    image.Mutate(x => x.Resize(50, 75));
                    image.SaveAsync(MiniPicPath);
                }

            }
        }

        public void AddColorForProduct(string color, Product product)
        {
            _db.Colors.Add(new Data.Entities.Product.Color { ProductId = product.ProductId, PC_Name = color });
        }

        public Tuple<List<ShowProductForIndex>, int> ShowProduct(int pageid = 1, string Filter = "", List<int> selectedgroup = null, string orderbytype = "featured", int take = 0)
        {
            if (take == 0)
            {
                take = 8;
            }
            var result = _db.Products.AsQueryable();
            //============================================================== Filter
            if (Filter is not null)
            {
                result = result.Where(p => p.ProductTitle.Contains(Filter) || p.Tags.Contains(Filter));
            }
            //=============================================================Groups

            if (selectedgroup != null && selectedgroup.Any())
            {
                foreach (var groupid in selectedgroup)
                {
                    result = result.Where(p => p.SubGroup == groupid || p.GroupId == groupid);
                }
            }
            //============================================================== OrderBy
            switch (orderbytype)
            {
                case "featured":
                    break;
                case "latest":
                    {
                        result = result.OrderByDescending(p => p.InsertDate);
                        break;
                    }
                case "special":
                    {
                        result = result.Where(p => p.Isspecial == true);
                        break;
                    }

            }

            int skip = (pageid - 1) * take;

            //================================================
            int pagecount = result
                .Select(r => new ShowProductForIndex
                {
                    ProductTitle = r.ProductTitle,
                    MainImageProduct = r.MainImageProduct,
                    ProductId = r.ProductId,
                    ProductPrice = r.ProductPrice,
                    Save = r.Save,
                }).Count() / take;

            //==================================================
            var query = result
                .Select(r => new ShowProductForIndex
                {
                    ProductTitle = r.ProductTitle,
                    MainImageProduct = r.MainImageProduct,
                    ProductId = r.ProductId,
                    ProductPrice = r.ProductPrice,
                    Save = r.Save,
                }).Skip(skip)
              .Take(take)
              .ToList();

            return Tuple.Create(query, pagecount);
        }

        public Product GetProductForShow(int productId)
        {
            return _db.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Colors)
                .FirstOrDefault(p => p.ProductId == productId);
        }

        public Product GetProductByProductId(int productId)
        {
            return _db.Products.Find(productId);
        }

        public void AddProductComment(ProductComment comment)
        {
            _db.ProductComments.Add(comment);
            _db.SaveChanges();
        }

        public Tuple<List<ProductComment>, int> GetAllComments(int productId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _db.ProductComments.Where(pc => pc.ProductId == productId && !pc.IsDelete).Count() / take;
            return Tuple.Create(_db.ProductComments.Include(u=> u.User)
                .Where(pc => pc.ProductId == productId && !pc.IsDelete)
                .Skip(skip).Take(take)
                .OrderByDescending(pc => pc.CreateDate)
                .ToList(), pageCount);
        }

        public List<Product> GetPopularProduct()
        {
            return _db.Products.Include(p => p.OrderDetails)
                .OrderByDescending(o => o.OrderDetails.Count)
                .Take(8)
                .ToList();
        }

        public List<Product> GetSpecialProduct()
        {
            return _db.Products.Where(p=>!p.IsDelete && p.Isspecial==true).Take(8).ToList();
        }

        public List<Product> GetLatestProduct()
        {
            return _db.Products.OrderByDescending(p=>p.InsertDate).Take(8).ToList();
        }

        public List<Product> GetAllProduct()
        {
            return _db.Products.Take(8).ToList();
        }
    }
}
