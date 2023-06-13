using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    [PermissionChecker(12)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
