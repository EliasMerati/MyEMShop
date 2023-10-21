using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.User;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Roles
{
    [PermissionChecker(3)]
    public class IndexModel : PageModel
    {
        #region Inject service
        private readonly IPermissionService _permissionService;
        public IndexModel(IPermissionService permissionService)
        {
            _permissionService = permissionService;
        }
        #endregion

        public IList<Role> Roles { get; set; }
        public void OnGet()
        {
            Roles = _permissionService.GetRoles();
        }
    }
}
