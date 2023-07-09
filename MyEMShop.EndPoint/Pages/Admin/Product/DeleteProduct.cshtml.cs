using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class DeleteProductModel : PageModel
    {
        #region Injection
        private readonly IProductService _productService;
        public DeleteProductModel(IProductService productService)
        {
            _productService = productService;
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
            return RedirectToPage("Index");
        }
    }
}
