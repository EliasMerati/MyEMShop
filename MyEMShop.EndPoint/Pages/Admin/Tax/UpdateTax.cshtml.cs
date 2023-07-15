using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Tax
{
    public class UpdateTaxModel : PageModel
    {
        private readonly ITaxService _taxService;
        #region Inject
        public UpdateTaxModel(ITaxService taxService)
        {
            _taxService = taxService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Tax.Tax Tax { get; set; }
        public void OnGet(int id)
        {
            Tax = _taxService.GetTaxById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _taxService.UpdateTax(Tax);
            return RedirectToPage("Index");
        }
    }
}
