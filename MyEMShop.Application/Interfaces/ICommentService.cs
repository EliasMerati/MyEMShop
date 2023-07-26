using MyEMShop.Data.Dtos.IsRead;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace MyEMShop.Application.Interfaces
{
    public interface ICommentService
    {
        void AddProductComment(ProductComment comment);
        Tuple<List<ProductComment>, int> GetAllComments(int productId, int pageId = 1);
        int GetAllProductComments(int productId);
        List<ProductComment> ShowAllCommentsForAdmin(IsAdminRead adminRead);
        void AccessComment(int productId,int commentId);
    }
}
