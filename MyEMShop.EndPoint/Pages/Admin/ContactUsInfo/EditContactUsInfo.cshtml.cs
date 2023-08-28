using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUsInfo
{
    public class EditContactUsInfoModel : PageModel
    {
        #region Inject Services
        private readonly IContactUsInfoService _contactUsInfoService;
        public EditContactUsInfoModel(IContactUsInfoService contactUsInfoService)
        {
            _contactUsInfoService = contactUsInfoService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.ContactUs.ContactUsInfo ContactUsInfo { get; set; }
        public void OnGet(int id)
        {
            ContactUsInfo = _contactUsInfoService.GetContactUsInfoById(id);
        }

        public IActionResult OnPost(IFormFile MainimgContactUs)
        {
            _contactUsInfoService.EditContactUsInfo(ContactUsInfo, MainimgContactUs);
            return RedirectToPage("Index");
        }
    }
}
