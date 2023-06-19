using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using System.Linq;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class EditProductModel : PageModel
    {
        #region Inject Service
        private readonly IProductService _productService;
        public EditProductModel(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        [BindProperty]
        public Data.Entities.Product.Product product { get; set; }
        public void OnGet(int id)
        {
            product =  _productService.GetProductById(id);

            //====================================================================================Bind DropDown

            var groups = _productService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text",product.GroupId);

            var subgroups = _productService.GetSubGroupsForManageProduct(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subgroups, "Value", "Text",product.SubGroup??0);

            var productlevel = _productService.GetProductLevel();
            ViewData["ProductLevel"] = new SelectList(productlevel, "Value", "Text",product.PL_Id);

            var size = _productService.GetProductSize();
            ViewData["ProductSize"] = new SelectList(size, "Value", "Text",product.PS_Id);
        }

        public IActionResult OnPost(IFormFile DemoProduct)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdateProduct(product, DemoProduct);
            return RedirectToPage("Index");
        }
    }
}
