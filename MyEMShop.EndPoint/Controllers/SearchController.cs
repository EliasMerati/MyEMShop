using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyEMShop.EndPoint.Controllers
{
    public class SearchController : Controller
    {
        #region Inject Service
        private readonly IProductService _productService;
        private readonly IGroupService _groupService;
        private readonly IOrderService _orderService;
        private readonly IUserPannelService _userPannel;
        private readonly IDistributedCache _cache;
        public SearchController(IProductService productService
            , IOrderService orderService
            , IUserPannelService userPannel,
              IGroupService groupService,
              IDistributedCache cache)
        {
            _productService = productService;
            _orderService = orderService;
            _userPannel = userPannel;
            _groupService = groupService;
            _cache = cache;
        }
        #endregion


        public IActionResult Index(int pageid = 1, string Filter = "", List<int> selectedgroup = null, string orderbytype = "featured", int take = 8)
        {
            ViewBag.pageid = pageid;
            ViewBag.SelectedGroup = selectedgroup;
            ViewBag.Groups = _groupService.GetGroups();
            return View(_productService.ShowProduct(pageid, Filter, selectedgroup, orderbytype, 12));
        }


        [Route("/ShowProduct/{id}")]
        public IActionResult ShowProduct(int id)
        {
            ViewBag.special = _productService.GetSpecialProduct();
            ViewBag.popular = _productService.GetPopularProduct();
            ViewBag.product = _productService.GetAllProduct();

            //#region Caching
            //Product product = new Product();
            //var showproductcache = _cache.GetAsync(CatchHelper.GenerateShowProductCacheKey()).Result;
            //if (showproductcache is not null)
            //{
            //    product = JsonSerializer.Deserialize<Product>(showproductcache);
            //}
            //else
            //{
            //    product = _productService.GetProductForShow(id);
            //    var JsonData = JsonSerializer.Serialize(product);
            //    byte[] encodeJson = Encoding.UTF8.GetBytes(JsonData);
            //    var option = new DistributedCacheEntryOptions().SetSlidingExpiration(CatchHelper.DefaultCatchDuration);
            //    _cache.SetAsync(CatchHelper.GenerateShowProductCacheKey(), encodeJson, option);

            //    if (product is null)
            //    {
            //        return Redirect("NotFound");
            //    }
            //}
            //#endregion



            return View(_productService.GetProductForShow(id));
        }

        [Authorize]
        public IActionResult BuyProduct(int id)
        {
            int orderId = _orderService.AddOrder(User.Identity.Name, id);
            return Redirect("/UserPannel/Order/ShowOrder/" + orderId);
        }

        [HttpPost]
        public IActionResult AddComment(ProductComment productComment)
        {
            productComment.IsDelete = false;
            productComment.CreateDate = DateTime.Now;
            productComment.UserId = _userPannel.GetUserIdByUserName(User.Identity.Name);
            _productService.AddProductComment(productComment);
            return View("ShowComment", _productService.GetAllComments(productComment.ProductId));
        }

        public IActionResult ShowComment(int id, int pageId = 1)
        {
            return View(_productService.GetAllComments(id, pageId));
        }
    }

}
