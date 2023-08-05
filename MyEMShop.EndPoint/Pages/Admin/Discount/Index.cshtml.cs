using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    [PermissionChecker(29)]
    public class IndexModel : PageModel
    {
        
        #region Inject

        private readonly IDiscountService _discountService;
        public IndexModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }
        #endregion


        public List<MyEMShop.Data.Entities.Order.Discount> Discounts { get; set; }
        public void OnGet(int pageId = 1)
        {
            Discounts = _discountService.GetDiscounts(pageId).Item1;
            ViewData["rowsCount"]= _discountService.GetDiscounts().Item2;
            ViewData["pageId"] = pageId;
        }
    }
}
