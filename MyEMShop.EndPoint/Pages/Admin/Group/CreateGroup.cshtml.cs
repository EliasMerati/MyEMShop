using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    [PermissionChecker(17)]
    public class CreateGroupModel : PageModel
    {

        #region Injection
        private readonly IGroupService _groupService;
        public CreateGroupModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Product.ProductGroup group { get; set; }
        public void OnGet(int? id)
        {
            group = new Data.Entities.Product.ProductGroup()
            {
                ParentId = id
            };
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _groupService.AddGroup(group);
            return RedirectToPage("Index");
        }
    }
}
