using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyEMShop.Application.Interfaces;
using MyEMShop.EndPoint.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyEMShop.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        #region Inject Services
        private readonly ILogger<HomeController> _logger;
        private readonly IUserWalletService _userWalletService;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IUserWalletService userWalletService, IProductService productService)
        {
            _logger = logger;
            _userWalletService = userWalletService;
            _productService = productService;
        }
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        #region OnlinePayment

        [Route("OnlinePayment/{id}")]
        public IActionResult OnlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok" &&
                HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];
                var wallet = _userWalletService.GetWalletByWalletId(id);
                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
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

            list.AddRange(_productService.GetSubGroupsForManageProduct(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}
