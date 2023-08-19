using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Banners;

namespace MyEMShop.EndPoint.Pages.Admin.Banners
{
    [PermissionChecker(47)]
    public class RemoveLeftBannerModel : PageModel
    {
        #region Injection
        private readonly IBannerService _BannerService;
        public RemoveLeftBannerModel(IBannerService BannerService)
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
            _BannerService.RemoveLeftBanner(id);
            return RedirectToPage("Index");
        }
    }
}
