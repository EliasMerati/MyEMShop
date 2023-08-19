using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Tax
{
    [PermissionChecker(33)]
    public class CreateTaxModel : PageModel
    {
        #region Inject
        private readonly ITaxService _taxService;
        public CreateTaxModel(ITaxService taxService)
        {
            _taxService = taxService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Tax.Tax Tax { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _taxService.CreateTax(Tax);
            return RedirectToPage("Index");
        }
    }
}
