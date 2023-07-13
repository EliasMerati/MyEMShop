using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class DeleteProductModel : PageModel
    {
        #region Injection
        private readonly IProductService _productService;
        private readonly IDistributedCache _cache;
        public DeleteProductModel(IProductService productService, IDistributedCache cache)
        {
            _productService = productService;
            _cache= cache;
        }

        #endregion

        [BindProperty]
        public Data.Entities.Product.Product product { get; set; }
        public void OnGet(int id)
        {
            ViewData["id"] = id;
            product = _productService.GetProductById(id);
        }

        public IActionResult OnPost(int id)
        {
            var product = _productService.GetProductById(id);
            _productService.DeleteProduct(product);
            _cache.RemoveAsync(CatchHelper.GenerateShowProductCacheKey());
            return RedirectToPage("Index");
        }
    }
}
