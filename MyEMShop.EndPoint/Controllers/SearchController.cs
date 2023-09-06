using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Dtos.IsRead;
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
        private readonly ICommentService _commentService;
        private readonly IGroupService _groupService;
        private readonly IOrderService _orderService;
        private readonly IUserPannelService _userPannel;
        public SearchController(IProductService productService, ICommentService commentService
            , IOrderService orderService
            , IUserPannelService userPannel,
              IGroupService groupService
)
        {
            _productService = productService;
            _commentService = commentService;
            _orderService = orderService;
            _userPannel = userPannel;
            _groupService = groupService;
        }
        #endregion


        public IActionResult Index(int pageid = 1, string Filter = "", List<int> selectedgroup = null, string orderbytype = "")
        {
            ViewBag.pageid = pageid;
            ViewBag.SelectedGroup = selectedgroup;
            ViewBag.Groups = _groupService.GetGroups();
            return View(_productService.ShowProduct(pageid, Filter, selectedgroup, orderbytype));
        }


        [Route("/ShowProduct/{id}/{title}")]
        public IActionResult ShowProduct(int id,string title)
        {
            ViewBag.CommentCount = _commentService.GetAllProductComments(id);
            ViewBag.special = _productService.GetSpecialProduct();
            ViewBag.popular = _productService.GetPopularProduct();
            ViewBag.product = _productService.GetAllProductLikeName(id);

            return View(_productService.GetProductForShow(id));
        }

        [Route("p/{key}")]
        public IActionResult ShortKeyRedirect(string key)
        {

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
            productComment.AdminRead = IsAdminRead.IsFalse;
            productComment.CreateDate = DateTime.Now;
            productComment.UserId = _userPannel.GetUserIdByUserName(User.Identity.Name);
            _commentService.AddProductComment(productComment);
            return View("ShowComment", _commentService.GetAllComments(productComment.ProductId));
        }

        public IActionResult ShowComment(int id, int pageId = 1)
        {
            return View(_commentService.GetAllComments(id, pageId));
        }

        public IActionResult AccessComment(int productId , int commentId) 
        {
            _commentService.AccessComment(productId,commentId);
            return Redirect("/Admin/Comments");
        }

        public IActionResult DeleteComment(int productId, int commentId)
        {
            _commentService.DeleteComment(productId, commentId);
            return Redirect("/Admin/Comments");
        }
    }

}
