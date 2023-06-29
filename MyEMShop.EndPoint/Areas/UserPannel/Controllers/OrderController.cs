using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class OrderController : Controller
    {
        #region Injection
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowOrder(int id,bool finall=false)
        {
            var order = _orderService.GetOrderForUserPannel(User.Identity.Name, id);
            if (order is null)
            {
                return Redirect("NotFound");
            }
            ViewBag.final = finall;
            return View(order);
        }

        public IActionResult FinalOrder(int id)
        {
            if (_orderService.FinallyOrder(User.Identity.Name , id))
            {
                return Redirect("/UserPannel/Order/" + id + "?finall = true");
            }
            return BadRequest();
        }
    }
}
