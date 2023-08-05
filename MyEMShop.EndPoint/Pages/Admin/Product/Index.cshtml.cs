using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.ProductDto;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    [PermissionChecker(12)]
    public class IndexModel : PageModel
    {
        private readonly IProductService _productService;
        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<GetProductForAdminDto> products { get; set; }
        public void OnGet(int pageId = 1)
        {
            products = _productService.GetProducts(pageId).Item1;
            ViewData["rowsCount"] = _productService.GetProducts().Item2;
            ViewData["pageId"] = pageId;
        }
    }
}
