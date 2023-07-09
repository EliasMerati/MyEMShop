using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class EditGroupModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        public EditGroupModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Product.ProductGroup group { get; set; }
        public void OnGet(int id)
        {
            group = _groupService.GetGroupById(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _groupService.UpdateGroup(group);
            return RedirectToPage("Index");
        }
    }
}
