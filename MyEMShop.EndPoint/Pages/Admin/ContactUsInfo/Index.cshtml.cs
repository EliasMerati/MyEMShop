using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.ContactUsInfo
{
    public class IndexModel : PageModel
    {
        #region Inject Services
        private readonly IContactUsInfoService _contactUsInfo;
        public IndexModel(IContactUsInfoService contactUsInfo)
        {
            _contactUsInfo = contactUsInfo;
        }
        #endregion

        public MyEMShop.Data.Entities.ContactUs.ContactUsInfo ContactUsInfo { get; set; }
        public void OnGet()
        {
            ContactUsInfo = _contactUsInfo.GetContactUsInfo();
        }
    }
}
