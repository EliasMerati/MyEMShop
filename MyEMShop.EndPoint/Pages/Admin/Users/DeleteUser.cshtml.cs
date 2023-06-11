using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    [PermissionChecker(6)]
    public class DeleteUserModel : PageModel
    {
        #region Inject Service
        private readonly IUserPannelService _userPannel;
        private readonly IManageUserService _manageUser;

        public DeleteUserModel(IUserPannelService userPannel, IManageUserService manageUser)
        {
            _userPannel = userPannel;
            _manageUser = manageUser;
        }
        #endregion

        public ShowUserInformationForPannelDto showUser { get; set; }
        public void OnGet(int id)
        {
            ViewData["id"] = id;
            showUser = _userPannel.GetUserInfo(id);
        }

        public IActionResult OnPost(int userId) 
        {
            _manageUser.DeleteUser(userId);
            return RedirectToPage("Index");
        }
    }
}
