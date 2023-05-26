using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Win32;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.User;
using System;

namespace MyEMShop.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        #region Injection
        private readonly IAccountServices _AccountServices;
        public AccountController(IAccountServices accountServices)
        {
            _AccountServices = accountServices;
        }
        #endregion

        #region Register
        [HttpGet]
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterDto register)
        {
            if (!ModelState.IsValid) { return View(register); }

            if (_AccountServices.IsExistEmail(FixedEmail.Fix(register.Email)))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده تکراری است ");
                return View(register);
            }
            if (_AccountServices.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری وارد شده تکراری است ");
                return View(register);
            }
            var user = new User()
            {
                UserName = register.UserName,
                Email = register.Email,
                Activecode = GenerateCode.GenerateUniqueCode(),
                IsActive = false,
                RoleId = 2,
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
            };
            _AccountServices.Register(user);
            return View("_Success",user);
        }
        #endregion

        #region Login
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDto login)
        {
            if (!ModelState.IsValid) { return View(login); }
            var user = _AccountServices.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("Email", "حساب کاربری شما فعال نیست");
                }
                
            }
            ModelState.AddModelError("Email", "کاربری با مشخصات فوق یافت نشد");
            return View(login);
        }
        #endregion

        #region Active Account
        public IActionResult ActiveAccount(string id)
        {
            ViewBag.Isactive = _AccountServices.ActiveAccount(id);
            return View();
        }
        #endregion

        #region ForgotPassword


        [Route("ForgotPassword")]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword(ChangePasswordDto change)
        {
            string CurrentUserName = User.Identity.Name;
            if (!ModelState.IsValid) { return View(change); }
            if (!_AccountServices.CompareOldPassword(change.OldPassword , CurrentUserName))
            {
                ModelState.AddModelError("OldPassword", "کلمه ی عبور فعلی صحیح نمیباشد ");
                return View(change);
            }
            _AccountServices.ChangeNewPassword(CurrentUserName, change.Password);
            return Redirect(nameof(LogOut));
        }
        #endregion

        #region LogOut
        [Route("LogOut")]
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect(nameof(Login));
        }
        #endregion

    }
}
