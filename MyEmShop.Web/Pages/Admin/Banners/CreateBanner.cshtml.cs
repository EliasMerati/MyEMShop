using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.Banners
{
    [PermissionChecker(41)]
    public class CreateBannerModel : PageModel
    {

        #region Inject
        private readonly IBannerService _bannerService;
        public CreateBannerModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        #endregion

        [BindProperty]
        public Banner Banner { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile MainimgBanner)
        {
            _bannerService.AddLeftBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostMiddleLeft(IFormFile MainimgBanner)
        {
            _bannerService.AddMiddleLeftBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostMiddleRight(IFormFile MainimgBanner)
        {
            _bannerService.AddMiddleRightBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRight(IFormFile MainimgBanner)
        {
            _bannerService.AddRightBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }
    }
}
