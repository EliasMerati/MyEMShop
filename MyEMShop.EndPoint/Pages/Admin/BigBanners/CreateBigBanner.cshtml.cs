using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.BigBanners
{
    [PermissionChecker(42)]
    public class CreateBigBannerModel : PageModel
    {
        #region Inject
        private readonly IBigBannerService _bigBannerService;
        public CreateBigBannerModel(IBigBannerService bigBannerService)
        {
            _bigBannerService = bigBannerService;
        }
        #endregion

        [BindProperty]
        public Banner Banner { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile MainimgBanner)
        {
            _bigBannerService.AddLargeLeftBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRight(IFormFile MainimgBanner)
        {
            _bigBannerService.AddLargeRightBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }
    }
}
