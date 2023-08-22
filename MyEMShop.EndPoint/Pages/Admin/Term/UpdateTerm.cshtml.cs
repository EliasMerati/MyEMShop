using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Term
{
    public class UpdateTermModel : PageModel
    {
        #region Inject Service
        private readonly ITermsService _termsService;
        public UpdateTermModel(ITermsService termsService)
        {
            _termsService = termsService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Terms.Term Term { get; set; }
        public void OnGet(int id)
        {
            Term = _termsService.GetTermById(id);
        }

        public IActionResult OnPost()
        {
            _termsService.UpdateTerm(Term);
            return RedirectToPage("Index");
        }
    }
}
