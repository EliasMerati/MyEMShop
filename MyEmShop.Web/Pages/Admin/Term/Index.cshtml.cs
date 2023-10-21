using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Term
{
    [PermissionChecker(56)]
    public class IndexModel : PageModel
    {
        #region Inject Service
        private readonly ITermsService _termsService;
        public IndexModel(ITermsService termsService)
        {
            _termsService = termsService;
        }

        #endregion

        public MyEMShop.Data.Entities.Terms.Term Term { get; set; }
        public void OnGet()
        {
            Term = _termsService.GetTerm();
        }
    }
}
