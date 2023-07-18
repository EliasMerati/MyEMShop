using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Dtos.OrderState;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Orders
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IOrderService _orderService;
        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion

        public  List<OrdersDto> Orders { get; set; }
        public void OnGet(OrderState orderState)
        {
            Orders = _orderService.GetOrdersForAdmin(orderState);
        }
    }
}
