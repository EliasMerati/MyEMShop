using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUsInfo
{
    [PermissionChecker(73)]
    public class AddContactUsInfoModel : PageModel
    {
        #region `Inject Services
        private readonly IContactUsInfoService _contactUsInfoService;
        public AddContactUsInfoModel(IContactUsInfoService contactUsInfoService)
        {
            _contactUsInfoService = contactUsInfoService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.ContactUs.ContactUsInfo ContactUsInfo { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(IFormFile MainimgContactUs)
        {
            _contactUsInfoService.AddContactUsInfo(ContactUsInfo, MainimgContactUs);
            return RedirectToPage("Index");
        }
    }
}
