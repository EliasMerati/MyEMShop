using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class CommentService : ICommentService
    {
        #region Injection
        private readonly DatabaseContext _db;
        public CommentService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddProductComment(ProductComment comment)
        {
            _db.ProductComments.Add(comment);
            _db.SaveChanges();
        }

        public Tuple<List<ProductComment>, int> GetAllComments(int productId, int pageId = 1)
        {
            int take = 5;
            int skip = (pageId - 1) * take;
            int pageCount = _db.ProductComments.Where(pc => pc.ProductId == productId && !pc.IsDelete).Count() / take;
            return Tuple.Create(_db.ProductComments.Include(u => u.User)
                .Where(pc => pc.ProductId == productId && !pc.IsDelete)
                .Skip(skip).Take(take)
                .OrderByDescending(pc => pc.CreateDate)
                .ToList(), pageCount);
        }
    }
}
