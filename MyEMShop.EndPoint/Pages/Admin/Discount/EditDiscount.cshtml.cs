using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Globalization;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    public class EditDiscountModel : PageModel
    {
        #region Inject
        private readonly IOrderService _orderService;
        private readonly IDiscountService _discountService;
        public EditDiscountModel(IOrderService orderService, IDiscountService discountService)
        {
            _orderService = orderService;
            _discountService = discountService;
        }
        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Order.Discount Discount { get; set; }
        public void OnGet(int id)
        {
           Discount = _discountService.GetDiscountById(id);
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

            if (!ModelState.IsValid) { return Page(); }
            _discountService.UpdateDiscount(Discount);
            return RedirectToPage("Index");
        }
    }
}
