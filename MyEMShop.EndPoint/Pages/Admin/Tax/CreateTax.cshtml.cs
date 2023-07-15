using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Tax
{
    public class CreateTaxModel : PageModel
    {
        private readonly ITaxService _taxService;
        #region Inject
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
