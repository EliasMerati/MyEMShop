using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;

namespace MyEMShop.EndPoint.Pages.Admin
{
    [PermissionChecker(1)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
