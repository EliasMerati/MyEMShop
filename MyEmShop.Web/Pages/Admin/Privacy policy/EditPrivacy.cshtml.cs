using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.PrivacyPolicy;

namespace MyEMShop.EndPoint.Pages.Admin.Privacy_policy
{
    [PermissionChecker(59)]
    public class EditPrivacyModel : PageModel
    {
        #region Injection
        private readonly IPrivacyService _privacyService;
        public EditPrivacyModel(IPrivacyService privacyService)
        {
            _privacyService = privacyService;
        }
        #endregion

        [BindProperty]
        public Privacy Privacy { get; set; }
        public void OnGet(int id)
        {
            Privacy = _privacyService.GetPrivacyById(id);
        }
        public IActionResult OnPost()
        {
            _privacyService.UpdatePrivacy(Privacy);
            return RedirectToPage("Index");
        }
    }
}
