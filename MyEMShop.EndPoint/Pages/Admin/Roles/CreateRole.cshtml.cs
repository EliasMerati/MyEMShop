using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.User;

namespace MyEMShop.EndPoint.Pages.Admin.Roles
{
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
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Role.IsDelete = false;
            _permissionService.AddRole(Role);
            return RedirectToPage("Index");
        }
    }
}
