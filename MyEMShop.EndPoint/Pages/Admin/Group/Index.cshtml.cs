using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        List<MyEMShop.Data.Entities.Product.ProductGroup> ProductGroups { get; set; }
        public void OnGet()
        {
            ProductGroups = _productService.GetGroups();
        }
    }
}
