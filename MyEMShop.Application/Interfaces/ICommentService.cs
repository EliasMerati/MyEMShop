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
        Tuple<List<ProductComment>, int> ShowAllCommentsForAdmin(IsAdminRead adminRead,int pageId=1);
        Tuple<List<ProductComment>, int> ShowUserComments(int UserId ,int pageId=1);
        void AccessComment(int productId,int commentId);
        void DeleteComment(int productId,int commentId);
    }
}
