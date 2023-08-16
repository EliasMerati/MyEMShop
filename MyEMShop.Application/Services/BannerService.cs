﻿using Microsoft.AspNetCore.Http;
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
    public class BannerService : IBannerService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public BannerService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddLeftBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-SmallLeft" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink,BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-2-400x200.jpg", BannerName = "", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
        }

        public void AddMiddleLeftBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-SmallMiddleLeft" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink, BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-1-400x200.jpg", BannerName = "", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
        }

        public void AddMiddleRightBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-SmallMiddleRight" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink, BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-1-400x200.jpg", BannerName = "", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
        }

        public void AddRightBanner(Banner banner, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                banner.BannerImage = GenerateCode.GenerateUniqueCode() + "-SmallRight" + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);

                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
                _db.Banners.Add(new Banner { BannerImage = banner.BannerImage, BannerName = banner.BannerName, BannerLink = banner.BannerLink, BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
            else
            {
                _db.Banners.Add(new Banner { BannerImage = "sample-banner-2-400x200.jpg", BannerName = "", BannerLink = "", BannerType = Data.Dtos.BannerType.BannerType.SmallBanner });
                _db.SaveChanges();
            }
        }

        public List<Banner> GetAllBanners()
        {
            return _db.Banners.Where(b=>b.BannerType == Data.Dtos.BannerType.BannerType.SmallBanner).ToList();
        }

        public Banner GetBannerById(int BannerId)
        {
            return _db.Banners.Find(BannerId);
        }

        public void RemoveLeftBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "SmallLeft")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }

        public void RemoveMiddleLeftBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "SmallMiddleLeft")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }

        public void RemoveMiddleRightBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "SmallMiddleRight")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }

        public void RemoveRightBanner(int BannerId)
        {
            var banner = _db.Banners.Find(BannerId);
            var bannerImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/banner/", banner.BannerImage);
            string[] Split = bannerImage.Split(new Char[] { '-' });
            if (Split[1] == "SmallRight")
            {
                File.Delete(bannerImage);
            }
            _db.Remove(banner);
            _db.SaveChanges();
        }
    }
}
