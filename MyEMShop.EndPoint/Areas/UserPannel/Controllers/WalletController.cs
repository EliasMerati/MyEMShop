using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class WalletController : Controller
    {
        #region Injection
        private readonly IUserWalletService _userWalletService;
        private readonly IOrderService _orderService;
        private readonly IUserPannelService _userPannel;
        private readonly ITaxService _taxService;

        public WalletController(IUserWalletService userWalletService,IOrderService orderService, IUserPannelService userPannel, ITaxService taxService)
        {
            _userWalletService = userWalletService;
            _orderService = orderService;
            _userPannel = userPannel;
            _taxService = taxService;
        }
        #endregion


        [Route("UserPannel/Wallet")]
        public IActionResult Index(int pageId = 1)
        {
            ViewBag.pageid = pageId;
            ViewBag.Wallets =_userWalletService.GetWallet(User.Identity.Name, pageId);
            return View();
        }

        [Route("UserPannel/Wallet")]
        [HttpPost]
        public IActionResult Index(ChargeWalletDto charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Wallets = _userWalletService.GetWallet(User.Identity.Name);
                return View(charge);
            }
           int walletid = _userWalletService.ChargeWallet(User.Identity.Name,"واریز" , charge.Amount);
            var user = _userPannel.GetUserByUserName(User.Identity.Name);
            #region Online Payment With Wallet

            var payment = new Zarinpal.Payment("",charge.Amount);
            var response = payment.PaymentRequest("واریز به حساب", $"https://localhost:44346/OnlineWalletPayment/{walletid}", user.Email, (user.PhoneNumber is not null) ? user.PhoneNumber : "");
            if (response.Result.Status is 100)
            {
                return Redirect($"https://zarinpal.com/pg/StartPay/{response.Result.Authority}");
            }
            else
            {
                return Content("متاسفانه در حال حاضر درگاه پرداخت در دسترس نیست ، لطفا چند دقیقه ی دیگر مجددا تلاش کنید. با تشکر");
            }
            #endregion
        }

        #region Online Pay
        public IActionResult OnlinePay()
        {
            var order = _orderService.OrderNotPayment();
            var user = _userPannel.GetUserByUserName(User.Identity.Name);
            if (order is null)
            {
                return Redirect("NotFound");
            }
            var payment = new Zarinpal.Payment("", order.OrderSum);
            var result = payment.PaymentRequest($"پرداخت فاکتور شماره ی {order.OrderId}", $"https://localhost:44346/OnlinePayment/{order.OrderId}", user.Email, (user.PhoneNumber is not null) ? user.PhoneNumber : "");
            if (result.Result.Status is 100)
            {
                return Redirect($"https://zarinpal.com/pg/StartPay/{result.Result.Authority}");
            }
            else
            {
                return Content("متاسفانه در حال حاضر درگاه پرداخت در دسترس نیست ، لطفا چند دقیقه ی دیگر مجددا تلاش کنید. با تشکر");
            }
        }
        #endregion

    }
}
