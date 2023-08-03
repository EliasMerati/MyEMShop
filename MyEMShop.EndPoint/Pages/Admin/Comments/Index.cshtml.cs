using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Dtos.IsRead;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;

namespace MyEMShop.EndPoint.Pages.Admin.Comments
{
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
        public void OnGet(IsAdminRead adminRead)
        {
            productComments = _commentService.ShowAllCommentsForAdmin(adminRead);
        }
    }
}