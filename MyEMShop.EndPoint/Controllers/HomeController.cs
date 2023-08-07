using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyEMShop.Application.Interfaces;
using MyEMShop.EndPoint.Models;
using Stimulsoft.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace MyEMShop.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        #region Inject Services
        private readonly ILogger<HomeController> _logger;
        private readonly IUserWalletService _userWalletService;
        private readonly IOrderService _orderService;
        private readonly IGroupService _groupService;
        private readonly IProductService _productService;


        public HomeController(ILogger<HomeController> logger
            , IUserWalletService userWalletService
            , IOrderService orderService
            , IGroupService groupService
            , IProductService productService
            )
        {
            var stimulKey = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Reports/license.key");
            if (System.IO.File.Exists(stimulKey))
            {
                StiLicense.LoadFromFile(stimulKey);
            }
            _logger = logger;
            _userWalletService = userWalletService;
            _orderService = orderService;
            _groupService = groupService;
            _productService = productService;

        }
        #endregion


        public IActionResult Index()
        {
            ViewBag.popularproduct = _productService.GetPopularProduct();
            ViewBag.Special = _productService.GetSpecialProduct();
            ViewBag.latest = _productService.GetLatestProduct();
            ViewBag.PopularForIndex = _productService.GetPopularProductForIndex();
            ViewBag.SpecialForIndex = _productService.GetSpecialProductForIndex();
            return View(_productService.ShowProduct().Item1);
        }

        #region OnlinePayment

        [Route("OnlinePayment/{id}")]
        public IActionResult OnlineWalletPayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var wallet = _userWalletService.GetWalletByWalletId(id);
                var payment = new Zarinpal.Payment("", wallet.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.Code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPay = true;
                    _userWalletService.UpdateWallet(wallet);
                }
            }
            return View();
        }

        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var order = _orderService.GetOrderById(id);
                var payment = new Zarinpal.Payment("", order.OrderSum);
                var res = payment.Verification(authority).Result;
                if (res.Status is 100)
                {
                    ViewBag.Code = res.RefId;
                    ViewBag.IsSuccess = true;
                    order.IsFinally = true;
                    _orderService.UpdateOrder(order);
                }
            }
            return View();
        }
        #endregion



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید" , Value = ""}
            };

            list.AddRange(_groupService.GetSubGroupsForManageProduct(id));
            return Json(new SelectList(list, "Value", "Text"));


        }

        [HttpPost]
        [Route("file-upload")]
        public IActionResult UploadImage(IFormFile upload, string CKEditorFuncNum, string CKEditor, string langCode)
        {
            if (upload.Length <= 0) return null;

            var fileName = Guid.NewGuid() + Path.GetExtension(upload.FileName).ToLower();

            var path = Path.Combine(
                Directory.GetCurrentDirectory(), "wwwroot/Template/image/product/CkEditors Image",
                fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                upload.CopyTo(stream);

            }

            var url = $"{"/Template/image/product/CkEditors Image/"}{fileName}";

            return Json(new { uploaded = true, url });
        }
    }
}
