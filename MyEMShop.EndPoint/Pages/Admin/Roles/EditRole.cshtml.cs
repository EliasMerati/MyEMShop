using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.User;

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
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _permissionService.UpdateRole(Role);
            return RedirectToPage("Index");
        }
    }
}
