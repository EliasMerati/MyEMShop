using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.Order;
using MyEMShop.Data.Dtos.OrderState;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Orders
{
    [PermissionChecker(23)]
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
        public void OnGet(OrderState orderState , int pageId = 1)
        {
            Orders = _orderService.GetOrdersForAdmin(orderState,pageId).Item1;
            ViewData["rowsCount"] = _orderService.GetOrdersForAdmin(orderState).Item2;
            ViewData["pageId"] = pageId;
            ViewData["state"] = orderState;
        }
    }
}
