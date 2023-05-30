using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class HomeController : Controller
    {
        #region Injection
        private readonly IUserPannelService _userPannel;
        public HomeController(IUserPannelService userPannel)
        {
            _userPannel = userPannel;
        }
        #endregion

        #region Index
        [Route("/UserPannel/Index")]
        public IActionResult Index()
        {
            return View(_userPannel.GetUserInfo(User.Identity.Name));
        }
        #endregion

        #region Edit
        [HttpGet]
        [Route("/UserPannel/Edit")]
        public IActionResult Edit()
        {
            var user = _userPannel.GetInfoForEdit(User.Identity.Name);
            return View(user);
        }

        [Route("/UserPannel/Edit")]
        [HttpPost]
        public IActionResult Edit(ShowUserInfoForEditPannelDto edit)
        {
            _userPannel.EditUserPannel(User.Identity.Name, edit);
            return Redirect("/UserPannel/Index");
        }
        #endregion

        #region ChangePassword
        [Route("UserPannel/ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Route("UserPannel/ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDto change)
        {
            var username = User.Identity.Name;
            if (!ModelState.IsValid)
                return View(change);

            if(!_userPannel.CompareOldPassword(change.OldPassword , username))
            {
                ModelState.AddModelError("OldPassword", "کلمه ی عبور فعلی صحیح نمیباشد");
            }

            _userPannel.ChangeNewPassword(username,change.Password);
            return Redirect("/LogOut");
        }
        #endregion

    }
}
