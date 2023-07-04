using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Globalization;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    public class CreateDiscountModel : PageModel
    {
        #region Inject
        private readonly IOrderService _orderService;
        public CreateDiscountModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Order.Discount Discount { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost(string StDate = "",string EdDate = "") 
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

            if (!ModelState.IsValid && _orderService.IsExistCode(Discount.DiscountCode)) { return Page(); }
            _orderService.AddDiscount(Discount);
            return RedirectToPage("Index");
        }

        public IActionResult OnGetCheckCode(string code)
        {
            return Content(_orderService.IsExistCode(code).ToString());
        }
    }
}
