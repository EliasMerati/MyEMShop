using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    public class ListDeletedUsersModel : PageModel
    {
        #region Injection
        private readonly IManageUserService _manageUser;
        public ListDeletedUsersModel(IManageUserService manageUser)
        {
            _manageUser = manageUser;
        }
        #endregion

        public UserListForAdminDto User { get; set; }
        public void OnGet(int pageid = 1, string email = "", string username = "", string name = "", string family = "")
        {
            User = _manageUser.GetDeleteUsers(pageid, email, username, name, family);
        }
    }
}
