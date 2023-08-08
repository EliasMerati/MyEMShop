using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.ProductDto;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class RefreshProductModel : PageModel
    {

        #region Inject
        private readonly IProductService _productService;
        public RefreshProductModel(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        public ShowProductForRefresh refresh { get; set; }
        public void OnGet(int id)
        {
            refresh = _productService.GetForRefresh(id);
            ViewData["id"] = id;
        }

        public IActionResult OnPost(int id)
        {
            _productService.RefreshProduct(id);
            return RedirectToPage("Index");
        }
    }
}
