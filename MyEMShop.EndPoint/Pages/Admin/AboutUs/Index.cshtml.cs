using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.AboutUs
{
    public class IndexModel : PageModel
    {

        #region Inject Service
        private readonly IAboutUsService _aboutUsService;
        public IndexModel(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        #endregion

        public MyEMShop.Data.Entities.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet()
        {
            AboutUs = _aboutUsService.GetAboutUs();
        }
    }
}
