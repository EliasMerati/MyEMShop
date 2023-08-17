using Microsoft.AspNetCore.Http;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Banners;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class BigBannerService : IBigBannerService
    {
        #region Inject Database
        private readonly DatabaseContext _db;

        public BigBannerService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddLargeLeftBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-BigLeft" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink, BannerType = Data.Dtos.BannerType.BannerType.BigBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-5-600X250.jpg", BannerName = "SampleBigBanner", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.BigBanner });
                _db.SaveChanges();
            }
        }

        public void AddLargeRightBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-BigRight" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink, BannerType = Data.Dtos.BannerType.BannerType.BigBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-5-600X250.jpg", BannerName = "SampleBigBanner", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.BigBanner });
                _db.SaveChanges();
            }
        }

        public List<Banner> GetAllBigBanners()
        {
            return _db.Banners.Where(b=> b.BannerType == Data.Dtos.BannerType.BannerType.BigBanner).ToList();
        }

        public Banner GetBannerById(int BannerId)
        {
            return _db.Banners.Find(BannerId);
        }

        public void RemoveLargeLeftBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "BigLeft")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }

        public void RemoveLargeRightBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "BigRight")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }
    }
}
