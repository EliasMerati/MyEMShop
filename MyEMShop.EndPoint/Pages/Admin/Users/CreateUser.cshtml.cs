using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using System.Collections.Generic;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    [PermissionChecker(4)]
    public class CreateUserModel : PageModel
    {
        #region Inject services
        private readonly IPermissionService _permissionService;
        private readonly IManageUserService _userService;
        public CreateUserModel(IPermissionService permissionService,IManageUserService userService)
        {
            _permissionService = permissionService;
            _userService = userService;
        }

        #endregion

        [BindProperty]
        public CreateUserWithadminDto createUser { get; set; }
        public void OnGet()
        {
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(IList<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            //Add User
           int UserId = _userService.AddUserByAdmin(createUser);
            //Add Roles
            _permissionService.SetRoles(SelectedRoles,UserId);

            return Redirect("/Admin/Users");

        }
    }
}
