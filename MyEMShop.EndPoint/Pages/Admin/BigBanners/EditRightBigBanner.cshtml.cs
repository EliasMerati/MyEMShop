using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.BigBanners
{
    public class EditRightBigBannerModel : PageModel
    {
        #region Inject
        private readonly IBigBannerService _bigBannerService;
        public EditRightBigBannerModel(IBigBannerService bigBannerService)
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

        public IActionResult OnPost(IFormFile MainimgBanner)
        {
            _bigBannerService.EditBigRightBanner(Banner, MainimgBanner);
            return RedirectToPage("Index");
        }
    }
}