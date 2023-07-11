using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    //[PermissionChecker(13)]
    public class CreateProductModel : PageModel
    {
        #region Inject Service
        private readonly IProductService _productService;
        private readonly IGroupService _groupService;
        private readonly IDistributedCache _cache;
        public CreateProductModel(IProductService productService, IGroupService groupService, IDistributedCache cache)
        {
            _productService = productService;
            _groupService = groupService;
            _cache = cache;
        }
        #endregion

        [BindProperty]
        public Data.Entities.Product.Product product { get; set; }
        public void OnGet()
        {
            
            var groups = _groupService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var subgroups = _groupService.GetSubGroupsForManageProduct(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text");

            var productlevel = _productService.GetProductLevel();
            ViewData["ProductLevel"] = new SelectList(productlevel, "Value", "Text");

            var size = _productService.GetProductSize();
            ViewData["ProductSize"] = new SelectList(size, "Value", "Text");
        }

        public IActionResult OnPost(List<IFormFile> imgProduct, IFormFile DemoProduct,IFormFile MainimgProduct , string Pcolor)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.CreateProduct(imgProduct,product, DemoProduct, MainimgProduct, Pcolor);
            _cache.RemoveAsync(CatchHelper.GenerateShowIndexCacheKey());
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            return RedirectToPage("Index");
        }


    }
}
