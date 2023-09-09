using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.IsRead;
using MyEMShop.Data.Entities.Product;
using MyEMShop.EndPoint.Filters;
using System;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Controllers
{
    [ServiceFilter(typeof(SaveVisitorsFilter))]
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
        public IActionResult ShowProduct(int id, string title)
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
            var product = _productService.GetByShortKey(key);
            if (product is null) { return View("NotFound"); }
            Uri uri = new Uri("https://localhost:44346/" + "ShowProduct/" + product.ProductId + "/" + product.ProductTitle.Trim().Replace(" ", "-"));
            return LocalRedirect(uri.AbsoluteUri);
        }

        [Authorize]
        public IActionResult BuyProduct(int id)
        {
            int orderId = _orderService.AddOrder(User.Identity.Name, id);
            return LocalRedirect("/UserPannel/Order/ShowOrder/" + orderId);
        }

        [HttpPost]
        public IActionResult AddComment(ProductComment productComment)
        {
            productComment.IsDelete = false;
            productComment.AdminRead = IsAdminRead.IsFalse;
            productComment.CreateDate = DateTime.Now;
            productComment.UserId = _userPannel.GetUserIdByUserName(User.Identity.Name);

            #region Sanitize Comment
            var sanitizer = new HtmlSanitizer();
            var resault = sanitizer.Sanitize(productComment.Comment);
            productComment.Comment = resault;
            #endregion

            _commentService.AddProductComment(productComment);
            return View("ShowComment", _commentService.GetAllComments(productComment.ProductId));
        }

        public IActionResult ShowComment(int id, int pageId = 1)
        {
            return View(_commentService.GetAllComments(id, pageId));
        }

        public IActionResult AccessComment(int productId, int commentId)
        {
            _commentService.AccessComment(productId, commentId);
            return LocalRedirect("/Admin/Comments");
        }

        public IActionResult DeleteComment(int productId, int commentId)
        {
            _commentService.DeleteComment(productId, commentId);
            return LocalRedirect("/Admin/Comments");
        }
    }

}
