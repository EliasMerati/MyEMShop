using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    [PermissionChecker(19)]
    public class DeleteGroupModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        private readonly IDistributedCache _cache;
        public DeleteGroupModel(IGroupService groupService, IDistributedCache cache)
        {
            _groupService = groupService;
            _cache = cache;
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
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            return RedirectToPage("Index");
        }
    }
}
