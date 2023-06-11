using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.User;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Roles
{
    [PermissionChecker(7)]
    public class CreateRoleModel : PageModel
    {
        #region Inject Service
        private readonly IPermissionService _permissionService;
        public CreateRoleModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }

        #endregion
        [BindProperty]
        public Role Role { get; set; }
        public void OnGet()
        {
            ViewData["Permission"] = _permissionService.GetAllPermissions();
        }

        public IActionResult OnPost( IList<int> SelectedPermission)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Role.IsDelete = false;
            int roleid = _permissionService.AddRole(Role);
            _permissionService.AddPermissionToRole(roleid, SelectedPermission);
            return RedirectToPage("Index");
        }
    }
}
