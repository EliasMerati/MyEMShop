using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using System.Collections;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Tax
{
    [PermissionChecker(32)]
    public class IndexModel : PageModel
    {
        private readonly ITaxService _taxService;
        #region inject
        public IndexModel(ITaxService taxService)
        {
            _taxService = taxService;
        }
        #endregion

        public List<MyEMShop.Data.Entities.Tax.Tax> Tax { get; set; }
        public void OnGet()
        {
            Tax = _taxService.ShowTax();
        }
    }
}
