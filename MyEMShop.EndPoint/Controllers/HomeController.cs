using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Dtos.ProductDto;
using MyEMShop.EndPoint.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MyEMShop.EndPoint.Controllers
{
    public class HomeController : Controller
    {
        #region Inject Services
        private readonly ILogger<HomeController> _logger;
        private readonly IUserWalletService _userWalletService;
        private readonly IGroupService _groupService;
        private readonly IProductService _productService;
        private readonly IDistributedCache _cache;


        public HomeController(ILogger<HomeController> logger
            , IUserWalletService userWalletService
            ,IGroupService groupService
            , IProductService productService
            ,IDistributedCache cache)
        {
            _logger = logger;
            _userWalletService = userWalletService;
            _groupService = groupService;
            _productService = productService;
            _cache = cache;
        }
        #endregion


        public IActionResult Index()
        {
            ViewBag.popularproduct = _productService.GetPopularProduct();
            ViewBag.Special = _productService.GetSpecialProduct();
            ViewBag.latest = _productService.GetLatestProduct();
            List<ShowProductForIndex>  showProduct = new List<ShowProductForIndex>();
           var showproductcache = _cache.GetAsync(CatchHelper.GenerateShowIndexCacheKey()).Result;
            if (showproductcache is not null)
            {
                showProduct = JsonSerializer.Deserialize<List<ShowProductForIndex>>(showproductcache);
            }
            else
            {
                showProduct = _productService.ShowProduct().Item1;
                string JsonData = JsonSerializer.Serialize(showProduct);
                byte[] encodeJson = Encoding.UTF8.GetBytes(JsonData);
                var option = new DistributedCacheEntryOptions().SetSlidingExpiration(CatchHelper.DefaultCatchDuration);
                _cache.SetAsync(CatchHelper.GenerateShowIndexCacheKey(), encodeJson, option);
            }
            return View(showProduct);
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
