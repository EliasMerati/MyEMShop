using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.PrivacyPolicy;

namespace MyEMShop.EndPoint.Pages.Admin.Privacy_policy
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IPrivacyService _privacyService;
        public IndexModel(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
        }
        #endregion

        public Privacy Privacy { get; set; }
        public void OnGet()
        {
            Privacy = _privacyService.GetPrivacy();
        }
    }
}
