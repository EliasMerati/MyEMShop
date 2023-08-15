using Microsoft.AspNetCore.Http;
using MyEMShop.Data.Entities.Banners;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IBannerService
    {
        List<Banner> GetAllBanners();
        Banner GetBannerById(int BannerId);
        void AddRightBanner(Banner banner, IFormFile ImgFile);
        void RemoveRightBanner(int BannerId);
        void AddLeftBanner(Banner banner, IFormFile ImgFile);
        void RemoveLeftBanner(int BannerId);
        void AddMiddleLeftBanner(Banner banner, IFormFile ImgFile);
        void RemoveMiddleLeftBanner(int BannerId);
        void AddMiddleRightBanner(Banner banner, IFormFile ImgFile);
        void RemoveMiddleRightBanner(int BannerId);

    }
}
