using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.BigBanners
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IBigBannerService _bigBanner;
        public IndexModel(IBigBannerService bigBanner)
        {
            _bigBanner = bigBanner;
        }
        #endregion

        public List<Banner> Banner { get; set; }
        public void OnGet()
        {
            Banner = _bigBanner.GetAllBigBanners();
        }
    }
}
