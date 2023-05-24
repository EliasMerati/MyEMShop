using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Dtos.UserDto;
using MyEMShop.Data.Entities.User;

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

        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        #endregion

    }
}
