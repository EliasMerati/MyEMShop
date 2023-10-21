using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.BigBanners
{
    [PermissionChecker(53)]
    public class RemoveLeftBigBannerModel : PageModel
    {
        #region Injection
        private readonly IBigBannerService _bigBannerService;
        public RemoveLeftBigBannerModel(IBigBannerService bigBannerService)
        {
            _bigBannerService = bigBannerService;
        }
        #endregion

        [BindProperty]
        public Banner Banner { get; set; }
        public void OnGet(int id)
        {
            Banner = _bigBannerService.GetBannerById(id);
        }

        public IActionResult OnPost(int id)
        {
            _bigBannerService.RemoveLargeLeftBanner(id);
            return RedirectToPage("Index");
        }
    }
}
