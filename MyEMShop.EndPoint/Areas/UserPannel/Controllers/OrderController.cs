﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.Order;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class OrderController : Controller
    {
        #region Injection
        private readonly IOrderService _orderService;
        private readonly IDiscountService _discountService;
        private readonly ITaxService _taxService;
        public OrderController(IOrderService orderService, IDiscountService discountService,ITaxService taxService)
        {
            _orderService = orderService;
            _discountService = discountService;
            _taxService = taxService;
        }
        #endregion


        public IActionResult Index()
        {
            return View(_orderService.GetUserOrders(User.Identity.Name));
        }

        public IActionResult ShowOrder(int id,bool finall=false , string type ="")
        {
            int tax =(int)_taxService.GetTax().TaxValue;
            ViewBag.tax = tax;
            var order = _orderService.GetOrderForUserPannel(User.Identity.Name, id);
            if (order is null)
            {
                return Redirect("NotFound");
            }
            ViewBag.TypeDiscount = type;
            ViewBag.final = finall;
            return View(order);
        }

        public IActionResult FinalOrder(int id)
        {
            if (_orderService.FinallyOrder(User.Identity.Name , id))
            {
                return Redirect("/UserPannel/Order/ShowOrder/" + id + "?finall = true");
            }
            return BadRequest();
        }

        public IActionResult UseDiscount(int orderId , string code)
        {
            ViewBag.discount = _discountService.GetDiscount(code);
            DiscountUseType type = _discountService.UseDiscount(orderId, code);
            return Redirect("/UserPannel/Order/ShowOrder/"+ orderId +"?Type =" + type.ToString());
        }

        [HttpPost]
        public IActionResult DeleteFromOrder(int orderId, int productid)
        {
            _orderService.DeleteFromOrder(orderId,productid);
            if (_orderService.IsOrderExist(orderId))
            {
                return Redirect("/UserPannel/Order/ShowOrder/" + orderId);
            }
            else
            {
                return Redirect("/UserPannel/Order/");
            }
        }

        public IActionResult DeleteOrder(int orderId)
        {
            _orderService.DeleteOrder(orderId);
            return Redirect("/UserPannel/Order/");
        }

        public IActionResult RefreshOrder(int orderId, int quantity, int productId)
        {
            _orderService.Refresh(quantity,orderId,productId);
            return Redirect("/UserPannel/Order/ShowOrder/" + orderId);
        }

        public IActionResult ChangeToIsSend(int orderId)
        {
            _orderService.ChangeStateToIsSend(orderId);
            return Redirect("/Admin/Orders/Index");
        }

        public IActionResult ChangeToIsDone(int orderId)
        {
            _orderService.ChangeStateToIsDone(orderId);
            return Redirect("/Admin/Orders/Index");
        }

        public IActionResult ChangeToIsCancelled(int orderId)
        {
            _orderService.ChangeStateToIsCancelled(orderId);
            return Redirect("/Admin/Orders/Index");
        }

        public IActionResult ShowOrderForAdmin(int orderId , int userId)
        {
            var order = _orderService.ShowOrderForAdmin(orderId, userId);
            return View("ShowOrder",order);
        }

    }
}
