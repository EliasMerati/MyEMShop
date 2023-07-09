using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.EndPoint.Pages.Admin.Product
{
    public class EditProductModel : PageModel
    {
        #region Inject Service
        private readonly IProductService _productService;
        private readonly IGroupService _groupService;
        public EditProductModel(IProductService productService, IGroupService groupService)
        {
            _productService = productService;
            _groupService = groupService;
        }
        #endregion

        [BindProperty]
        public Data.Entities.Product.Product product { get; set; }
        public void OnGet(int id)
        {
            product =  _productService.GetProductById(id);

            //====================================================================================Bind DropDown

            var groups = _groupService.GetGroupsForManageProduct();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text",product.GroupId);

            List<SelectListItem> subgroup= new List<SelectListItem>() 
            { 
                new SelectListItem(){Text = "انتخاب کنید", Value =""}
            };
            subgroup.AddRange(_groupService.GetSubGroupsForManageProduct(product.GroupId));
            string SelectedSubGroup = null;
            if (product.SubGroup is not null)
            {
                SelectedSubGroup = product.SubGroup.ToString();
            }
            ViewData["SubGroups"] = new SelectList(subgroup, "Value", "Text", SelectedSubGroup);

            var productlevel = _productService.GetProductLevel();
            ViewData["ProductLevel"] = new SelectList(productlevel, "Value", "Text",product.PL_Id);

            var size = _productService.GetProductSize();
            ViewData["ProductSize"] = new SelectList(size, "Value", "Text",product.PS_Id);
        }

        public IActionResult OnPost(IFormFile DemoProduct,IFormFile MainimgProduct)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdateProduct(product, DemoProduct, MainimgProduct);
            return RedirectToPage("Index");
        }
    }
}
