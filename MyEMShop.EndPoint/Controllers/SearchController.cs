using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Controllers
{
    public class SearchController : Controller
    {
        #region Inject Service
        private readonly IProductService _productService;
        public SearchController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion


        public IActionResult Index(int pageid = 1, string Filter = "", List<int> selectedgroup = null, string orderbytype = "featured", int take = 8)
        {
            ViewBag.pageid = pageid;
            ViewBag.SelectedGroup = selectedgroup;
            ViewBag.Groups = _productService.GetGroups();
            return View(_productService.ShowProduct(pageid, Filter, selectedgroup, orderbytype, 12));
        }

        [Route("/ShowProduct/{id}")]
        public IActionResult ShowProduct(int id)
        {
            var product = _productService.GetProductForShow(id);
            if (product is null)
            {
                return Redirect("NotFound");
            }
            return View(product);
        }
    }

}
