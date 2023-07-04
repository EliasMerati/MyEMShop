using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Discount
{
    public class IndexModel : PageModel
    {
        #region Inject
        private readonly IOrderService _orderService;
        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion


        public List<MyEMShop.Data.Entities.Order.Discount> Discounts { get; set; }
        public void OnGet()
        {
            Discounts = _orderService.GetDiscounts();
        }
    }
}
