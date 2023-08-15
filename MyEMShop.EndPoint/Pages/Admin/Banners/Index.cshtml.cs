using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Banners
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IBannerService _Banner;
        public IndexModel(IBannerService Banner)
        {
            _Banner = Banner;
        }
        #endregion

        public List<Banner> Banner { get; set; }
        public void OnGet()
        {
            Banner = _Banner.GetAllBanners();
        }
    }
}
