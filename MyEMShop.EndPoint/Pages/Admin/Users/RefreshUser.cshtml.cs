using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    public class RefreshUserModel : PageModel
    {
        private readonly IManageUserService _manageUser;
        private readonly IUserPannelService _userPannel;
        public RefreshUserModel(IManageUserService manageUser, IUserPannelService userPannel)
        {
            _manageUser = manageUser;
            _userPannel = userPannel;
        }
        public ShowUserInformationForPannelDto showUser { get; set; }

        public void OnGet(int id)
        {
            showUser = _userPannel.GetUserRefreshInfo(id);
            ViewData["id"] = id;
        }
        public IActionResult OnPost(int id)
        {
            _manageUser.ReturnUser(id);
            return RedirectToPage("Index");
        }
        
    }
}
