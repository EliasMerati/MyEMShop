using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class CreateGroupModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        private readonly IDistributedCache _cache;
        public CreateGroupModel(IGroupService groupService, IDistributedCache cache)
        {
            _groupService= groupService;
            _cache= cache;
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
            _cache.RemoveAsync(CatchHelper.GenerateShowIndexCacheKey());
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            
            return RedirectToPage("Index");
        }
    }
}
