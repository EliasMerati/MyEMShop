using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.AboutUs
{
    public class EditAboutUsModel : PageModel
    {
        #region Inject Service
        private readonly IAboutUsService _aboutUsService;
        public EditAboutUsModel(IAboutUsService aboutUsService)
        {
            _aboutUsService = aboutUsService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.AboutUs.AboutUs AboutUs { get; set; }
        public void OnGet(int id)
        {
            AboutUs = _aboutUsService.GetAboutUsById(id);
        }

        public IActionResult OnPost()
        {
            _aboutUsService.EditAboutUs(AboutUs);
            return RedirectToPage("Index");
        }
    }
}
