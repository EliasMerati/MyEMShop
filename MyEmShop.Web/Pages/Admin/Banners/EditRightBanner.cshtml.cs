using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.Banners
{
    [PermissionChecker(46)]
    public class EditRightBannerModel : PageModel
    {
        #region Inject
        private readonly IBannerService _bannerService;
        public EditRightBannerModel(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        #endregion

        [BindProperty]
        public Banner Banner { get; set; }
        public void OnGet(int id)
        {
            Banner = _bannerService.GetBannerById(id);
        }

        public IActionResult OnPost(IFormFile MainimgBanner)
        {
            _bannerService.EditRightBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }
    }
}
