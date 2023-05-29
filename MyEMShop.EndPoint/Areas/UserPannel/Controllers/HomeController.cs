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
        [Route("/UserPannel/Edit")]
        public IActionResult Edit()
        {
            return View(_userPannel.GetInfoForEdit(User.Identity.Name));
        }
        #endregion

    }
}
