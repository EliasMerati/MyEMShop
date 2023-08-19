using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Attribute;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.IsRead;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Comments
{
    [PermissionChecker(55)]
    public class IndexModel : PageModel
    {
        private readonly ICommentService _commentService;
        #region Inject
        public IndexModel(ICommentService commentService)
        {
            _commentService = commentService;
        }
        #endregion

        public List<ProductComment> productComments { get; set; }
        public void OnGet(IsAdminRead adminRead , int pageId =1)
        {
            productComments = _commentService.ShowAllCommentsForAdmin(adminRead,pageId).Item1;
            ViewData["rowsCount"] = _commentService.ShowAllCommentsForAdmin(adminRead).Item2;
            ViewData["pageId"] = pageId;
        }
    }
}
