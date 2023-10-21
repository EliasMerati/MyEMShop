using Microsoft.AspNetCore.Mvc;

namespace MyEmShop.Web.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
