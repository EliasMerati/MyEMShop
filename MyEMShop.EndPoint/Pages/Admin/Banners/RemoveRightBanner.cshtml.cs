using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.Banners
{
    public class RemoveRightBannerModel : PageModel
    {
        #region Injection
        private readonly IBannerService _BannerService;
        public RemoveRightBannerModel(IBannerService BannerService)
        {
            _BannerService = BannerService;
        }
        #endregion

        [BindProperty]
        public Banner Banner { get; set; }
        public void OnGet(int id)
        {
            Banner = _BannerService.GetBannerById(id);
        }

        public IActionResult OnPost(int id)
        {
            _BannerService.RemoveRightBanner(id);
            return RedirectToPage("Index");
        }
    }
}