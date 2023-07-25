using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    [PermissionChecker(18)]
    public class EditGroupModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        private readonly IDistributedCache _cache;
        public EditGroupModel(IGroupService groupService, IDistributedCache cache)
        {
            _groupService = groupService;
            _cache = cache;
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
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            return RedirectToPage("Index");
        }
    }
}
