using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Entities.Product;
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
        }
    }
}
