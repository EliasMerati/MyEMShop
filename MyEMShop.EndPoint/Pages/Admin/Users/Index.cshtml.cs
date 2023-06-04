using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.UserDto;
using System.Collections.Generic;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IManageUserService _manageUser;
        public IndexModel(IManageUserService manageUser)
        {
            _manageUser = manageUser;
        }
        #endregion

        public UserListForAdminDto User { get; set; }
        public void OnGet(int pageid = 1, string email = "" , string username = "" , string name = "", string family = "")
        {
            User = _manageUser.GetUsers(pageid,email,username,name,family);
        }
    }
}
