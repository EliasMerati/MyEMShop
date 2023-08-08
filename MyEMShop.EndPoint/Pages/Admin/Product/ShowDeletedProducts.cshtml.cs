using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.ProductDto;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class ShowDeletedProductsModel : PageModel
    {
        private readonly IProductService _productService;
        public ShowDeletedProductsModel(IProductService productService)
        {
            _productService = productService;
        }

        public List<GetProductForAdminDto> products { get; set; }
        public void OnGet(int pageId = 1)
        {
            products = _productService.GetDeletedProducts(pageId).Item1;
            ViewData["rowsCount"] = _productService.GetDeletedProducts().Item2;
            ViewData["pageId"] = pageId;
        }

    }
}
