using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using System.Globalization;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    [PermissionChecker(30)]
    public class CreateDiscountModel : PageModel
    {
        #region Inject
        private readonly IDiscountService _discountService;
        public CreateDiscountModel(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Order.Discount Discount { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string StDate = "", string EdDate = "")
        {
            if (StDate is not null)
            {
                string[] std = StDate.Split('/');
                Discount.StartDate = new System.DateTime(int.Parse(std[0])
                    , int.Parse(std[1])
                    , int.Parse(std[2])
                    , new PersianCalendar());
            }
            if (EdDate is not null)
            {
                string[] end = EdDate.Split('/');
                Discount.EndDate = new System.DateTime(int.Parse(end[0])
                    , int.Parse(end[1])
                    , int.Parse(end[2])
                    , new PersianCalendar());
            }

            if (!ModelState.IsValid && _discountService.IsExistCode(Discount.DiscountCode)) { return Page(); }
            _discountService.AddDiscount(Discount);

            return RedirectToPage("Index");
        }

        public IActionResult OnGetCheckCode(string code)
        {
            return Content(_discountService.IsExistCode(code).ToString());
        }
    }
}
