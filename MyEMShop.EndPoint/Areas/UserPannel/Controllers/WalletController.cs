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
            _userWalletService.ChargeWallet(User.Identity.Name,"واریز" , charge.Amount);
            // ToDO Online payment
            return null;
            
            
        }
    }
}
