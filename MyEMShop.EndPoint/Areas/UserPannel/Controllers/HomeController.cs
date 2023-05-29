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
        [Route("/UserPannel/Edit")]
        public IActionResult Edit()
        {
            return View(_userPannel.GetInfoForEdit(User.Identity.Name));
        }

        [Route("/UserPannel/Edit")]
        [HttpPost]
        public IActionResult Edit(ShowUserInfoForEditPannelDto edit)
        {
            _userPannel.EditUserPannel(User.Identity.Name, edit);
            return Redirect("/UserPannel/Index");
        }
        #endregion

    }
}
