using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Areas.UserPannel.Controllers
{
    [Area("UserPannel")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUserPannelService _userPannel;
        public HomeController(IUserPannelService userPannel)
        {
            _userPannel = userPannel;
        }

        [Route("/UserPannel/Index")]
        public IActionResult Index()
        {
            return View(_userPannel.GetUserInfo(User.Identity.Name));
        }

        [Route("/UserPannel/Edit")]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
