using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.AboutUs
{
    public class AddAboutUsModel : PageModel
    {
        #region Inject Service
        private readonly IAboutUsService _aboutUsService;
        public AddAboutUsModel(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _aboutUsService.AddAboutUs(AboutUs);
            return RedirectToPage("Index");
        }
    }
}
