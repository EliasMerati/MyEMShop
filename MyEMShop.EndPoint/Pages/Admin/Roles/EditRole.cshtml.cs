using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.User;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Roles
{
    public class EditRoleModel : PageModel
    {
        #region Inject Service
        private readonly IPermissionService _permissionService;
        public EditRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        #endregion
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet( int id)
        {
            Role = _permissionService.GetRoleById(id);
            ViewData["Permission"] = _permissionService.GetAllPermissions();
            ViewData["SelectedPermissions"] = _permissionService.PermissionsRole(id);
        }

        public IActionResult OnPost(IList<int> permissions)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _permissionService.UpdateRole(Role);
            _permissionService.UpdatePermissionsRole(Role.RoleId, permissions);
            return RedirectToPage("Index");
        }
    }
}
