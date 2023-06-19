using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    //[PermissionChecker(13)]
    public class CreateProductModel : PageModel
    {
        #region Inject Service
        private readonly IProductService _productService;
        public CreateProductModel(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        [BindProperty]
        public Data.Entities.Product.Product product { get; set; }
        public void OnGet()
        {
            var groups = _productService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var subgroups = _productService.GetSubGroupsForManageProduct(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text");

            var productlevel = _productService.GetProductLevel();
            ViewData["ProductLevel"] = new SelectList(productlevel, "Value", "Text");

            var size = _productService.GetProductSize();
            ViewData["ProductSize"] = new SelectList(size, "Value", "Text");
        }

        public IActionResult OnPost(List<IFormFile> imgProduct, IFormFile DemoProduct, List<string> Pcolor)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.CreateProduct(imgProduct, product, DemoProduct, Pcolor);
            return RedirectToPage("Index");
        }


    }
}
