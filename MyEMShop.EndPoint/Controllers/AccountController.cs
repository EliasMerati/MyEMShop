using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace MyEMShop.EndPoint.Controllers
{
    public class AccountController : Controller
    {
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
    }
}
