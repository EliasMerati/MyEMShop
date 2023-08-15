using MyEMShop.Data.Entities.Banners;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IBannerService
    {
        List<Banner> GetAllBanners();
        void AddRightBanner(Banner banner);
        void RemoveRightBanner(Banner banner);
        void AddLeftBanner(Banner banner);
        void RemoveLeftBanner(Banner banner);
        void AddMiddleLeftBanner(Banner banner);
        void RemoveMiddleLeftBanner(Banner banner);
        void AddMiddleRightBanner(Banner banner);
        void RemoveMiddleRightBanner(Banner banner);
        void AddLargeRightBanner(Banner banner);
        void RemoveLargeRightBanner(Banner banner);
        void AddLargeLeftBanner(Banner banner);
        void RemoveLargeLeftBanner(Banner banner);
    }
}
