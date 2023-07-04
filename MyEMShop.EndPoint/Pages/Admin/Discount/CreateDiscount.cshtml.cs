using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

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
    }
}
