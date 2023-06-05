using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.EndPoint.Pages.Admin.Users
{
    public class CreateUserModel : PageModel
    {
        #region Inject services
        private readonly IPermissionService _permissionService;
        public CreateUserModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
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
            return Redirect("/Admin/Users");

        }
    }
}
