using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    public class EditUserModel : PageModel
    {
        #region Injection
        private readonly IManageUserService _manageUser;
        private readonly IPermissionService _permissionService;
        public EditUserModel(IManageUserService manageUser, IPermissionService permissionService)
        {
            _manageUser = manageUser;
            _permissionService = permissionService;
        }
        #endregion

        [BindProperty]
        public EditUserWithAdminDto editUser { get; set; }
        
        public void OnGet(int id)
        {
            editUser = _manageUser.ShowUserInfoForEditWithAdmin(id);
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPut(IList<int> SelectedRoles)
        {
            if (!ModelState.IsValid) { return Page(); }

            _manageUser.EditUserByAdmin(editUser);

            //Add New Roles
            _permissionService.UpdateRoles(editUser.UserId,SelectedRoles);
            return RedirectToAction("Index");
        }
    }
}
