using Microsoft.AspNetCore.Http;
using MyEMShop.Data.Entities.Banners;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IBigBannerService
    {
        List<Banner> GetAllBigBanners();
        Banner GetBannerById(int BannerId);
        void AddLargeRightBanner(Banner banner, IFormFile ImgFile);
        void RemoveLargeRightBanner(int BannerId);
        void AddLargeLeftBanner(Banner banner, IFormFile ImgFile);
        void RemoveLargeLeftBanner(int BannerId);
        void EditBigRightBanner(Banner banner, IFormFile ImgFile);
        void EditBigLeftBanner(Banner banner, IFormFile ImgFile);
    }
}
