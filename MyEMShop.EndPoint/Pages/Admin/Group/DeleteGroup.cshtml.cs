using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class DeleteGroupModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        public DeleteGroupModel(IGroupService groupService)
        {
            _groupService = groupService;
        }

        #endregion
        [BindProperty]
        public MyEMShop.Data.Entities.Product.ProductGroup group { get; set; }
        public void OnGet(int id)
        {
            ViewData["id"] = id;
            group = _groupService.GetGroupById(id);
        }

        public IActionResult OnPost(int id)
        {
             var group =_groupService.GetGroupById(id);
            _groupService.DeleteGroup(group);
            return RedirectToPage("Index");
        }
    }
}
