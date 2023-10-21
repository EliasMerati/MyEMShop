using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEmShop.Web.Models;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using NuGet.Packaging;
using System.Diagnostics;

namespace MyEmShop.Web.Controllers
{
    public class HomeController : Controller
    {
        #region Inject Services
        private readonly ILogger<HomeController> _logger;
        private readonly IUserWalletService _userWalletService;
        private readonly IOrderService _orderService;
        private readonly IGroupService _groupService;
        private readonly IProductService _productService;
        private readonly IPrivacyService _privacyService;
        private readonly ITermsService _termsService;
        private readonly IFaqService _faqservice;
        private readonly IAboutUsService _aboutus;



        public HomeController(ILogger<HomeController> logger
            , IUserWalletService userWalletService
            , IOrderService orderService
            , IGroupService groupService
            , IProductService productService
            , IPrivacyService privacyService
            , ITermsService termsService
            , IFaqService faqservice
            , IAboutUsService aboutUs
            )
        {

            _logger = logger;
            _userWalletService = userWalletService;
            _orderService = orderService;
            _groupService = groupService;
            _productService = productService;
            _privacyService = privacyService;
            _termsService = termsService;
            _faqservice = faqservice;
            _aboutus = aboutUs;
        }
        #endregion
        [HttpGet("/")]
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
                var payment = new Zarinpal.Payment("e55a0dbd-7909-4dda-80ee-c8a6781e6aa1", wallet.Amount);
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

            var fileName = GenerateCode.GenerateUniqueCode() + Path.GetExtension(upload.FileName).ToLower();

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

        [Route("/Privacypolicy")]
        public IActionResult PrivacyPolicy()
        {
            var privacy = _privacyService.GetPrivacy();
            return View("PrivacyPolicy", privacy);
        }

        [Route("/Terms")]
        public IActionResult Terms()
        {
            var Term = _termsService.GetTerm();
            return View("Terms", Term);
        }

        [Route("/FAQ")]
        public IActionResult FAQ()
        {
            var faq = _faqservice.GetFaqList();
            return View("FAQ", faq);
        }


        [Route("/ContactUs")]
        public IActionResult ContactUs()
        {
            return View("ContactUs");
        }

        [Route("/AboutUs")]
        public IActionResult AboutUs()
        {
            var aboutus = _aboutus.GetAboutUs();
            return View("AboutUs", aboutus);
        }
    }
}