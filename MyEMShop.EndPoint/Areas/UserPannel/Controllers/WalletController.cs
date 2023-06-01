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
        public WalletController(IUserWalletService userWalletService)
        {
            _userWalletService = userWalletService;
        }
        #endregion


        [Route("UserPannel/Wallet")]
        public IActionResult Index()
        {
            ViewBag.Wallets = _userWalletService.GetWallet(User.Identity.Name);
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

            #region Online Payment
            var payment = new ZarinpalSandbox.Payment(charge.Amount);
            var response = payment.PaymentRequest("واریز به حساب", "https://localhost:44392/OnlinePayment" + walletid);
            if (response.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay" + response.Result.Authority);
            }
            #endregion

            return null;
            
            
        }
    }
}
