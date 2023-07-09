using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Group
{
    public class IndexModel : PageModel
    {
        #region Injection
        private readonly IGroupService _groupService;
        public IndexModel(IGroupService groupService)
        {
            _groupService= groupService;
        }
        #endregion

       public List<MyEMShop.Data.Entities.Product.ProductGroup> ProductGroups { get; set; }
        public void OnGet()
        {
            ProductGroups = _groupService.GetGroups();
        }
    }
}
