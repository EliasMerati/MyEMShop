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
        private readonly ICommentService _comment;
        public HomeController(IUserPannelService userPannel, ICommentService comment)
        {
            _userPannel = userPannel;
            _comment = comment;
        }
        #endregion

        #region Index
        [Route("/UserPannel/Index/{id?}")]
        public IActionResult Index(int? id)
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

            if (!_userPannel.CompareOldPassword(change.OldPassword, username))
            {
                ModelState.AddModelError("OldPassword", "کلمه ی عبور فعلی صحیح نمیباشد");
            }

            _userPannel.ChangeNewPassword(username, change.Password);
            return Redirect("/LogOut");
        }
        #endregion

        #region MyComment
        [Route("UserPannel/MyComment")]
        public IActionResult MyComment(int pageId = 1)
        {
            ViewBag.pageId = pageId;
            int userId = _userPannel.GetUserIdByUserName(User.Identity.Name);
            var result = _comment.ShowUserComments(userId, pageId);
            return View(result);
        }

        public IActionResult DeleteFromComments(int productId, int commentId)
        {
            _comment.DeleteComment(productId, commentId);
            return Redirect(nameof(MyComment));
        }
        #endregion

    }
}
