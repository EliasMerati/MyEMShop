using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MyEMShop.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        #region Injection
        private readonly IAccountServices _AccountServices;
        private readonly IViewRenderService _viewRender;
        public AccountController(IAccountServices accountServices, IViewRenderService viewRender)
        {
            _AccountServices = accountServices;
            _viewRender = viewRender;
        }
        #endregion

        //-------------------------------------------------------------------------------
       
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
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                RegisterDate = DateTime.Now,
            };
            _AccountServices.Register(user);
            #region Send Email
            var body = _viewRender.RenderToStringAsync("_ActiveEmail", user);
            SendEmail.Send(user.Email, "فعالسازی حساب کاربری", body);
            #endregion
            return View("_Success", user);
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
        public IActionResult Login(LoginDto login , string returnUrl = "/")
        {
            if (!ModelState.IsValid) { return View(login); }
            var user = _AccountServices.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var Principal = new ClaimsPrincipal(identity);
                    var property = new AuthenticationProperties { IsPersistent = login.IsPersistence };
                    HttpContext.SignInAsync(Principal, property);
                    if (returnUrl != "/")
                    {
                        return Redirect(returnUrl);
                    }
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
        public IActionResult ForgotPassword(ForgotPasswordDto forgot)
        {
            if (!ModelState.IsValid) { return View(forgot); }
            
            string FixEmail = FixedEmail.Fix(forgot.Email);
            var user = _AccountServices.GetUserByEmail(FixEmail);
            if (user is null)
            {
                ModelState.AddModelError("Email", " کاربری با مشخصات فوق یافت نشد");
                return View(forgot);
            }

            string body = _viewRender.RenderToStringAsync("_ForgotPassword",user);
            SendEmail.Send(user.Email,"فعالسازی کلمه ی عبور" , body);
            ViewBag.IsSuccess = true;
            return View();
        }
        #endregion

        #region ResetPassword


        [Route("ResetPassword")]
        public IActionResult ResetPassword( string id)
        {
            return View( new ResetPasswordDto {Activecode = id });
        }

        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordDto reset)
        {
            if (!ModelState.IsValid) { return View(reset); }
            var user = _AccountServices.GetUserByActiveCode(reset.Activecode);
            if (user is null) { return View("NotFound"); }
            string HashPassword = _AccountServices.HashPassword(reset.Password);
            user.Password = HashPassword;
            _AccountServices.UpdateUser(user);
            return Redirect("/Login") ;
        }
        //[HttpPost]
        //[Route("ResetPassword")]
        //public IActionResult ResetPassword(ChangePasswordDto change)
        //{
        //    string CurrentUserName = User.Identity.Name;
        //    if (!ModelState.IsValid) { return View(change); }
        //    if (!_AccountServices.CompareOldPassword(change.OldPassword, CurrentUserName))
        //    {
        //        ModelState.AddModelError("OldPassword", "کلمه ی عبور فعلی صحیح نمیباشد ");
        //        return View(change);
        //    }
        //    _AccountServices.ChangeNewPassword(CurrentUserName, change.Password);
        //    return Redirect(nameof(LogOut));
        //}
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
