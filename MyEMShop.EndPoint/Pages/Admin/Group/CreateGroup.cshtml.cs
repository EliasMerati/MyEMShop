using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class CreateGroupModel : PageModel
    {
        #region Injection
        private readonly IProductService _productService;
        public CreateGroupModel(IProductService productService)
        {
            _productService = productService;
        }

        #endregion

        [BindProperty]
        public MyEMShop.Data.Entities.Product.Product Product { get; set; }
        public void OnGet()
        {
        }
    }
}
