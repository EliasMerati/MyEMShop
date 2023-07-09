using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    public class IndexModel : PageModel
    {
        #region Inject
        
        private readonly IDiscountService _discountService;
        public IndexModel(IDiscountService discountService)
        {
            _discountService= discountService;
        }
        #endregion


        public List<MyEMShop.Data.Entities.Order.Discount> Discounts { get; set; }
        public void OnGet()
        {
            Discounts = _discountService.GetDiscounts();
        }
    }
}
