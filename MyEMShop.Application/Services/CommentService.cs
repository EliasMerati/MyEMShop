using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.IsRead;
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

            int pageCount = _db.ProductComments.Where(pc => pc.ProductId == productId  && pc.AdminRead == IsAdminRead.IsTrue).Count() / take;

            var commentsList = _db.ProductComments.Include(u => u.User)
                .Where(pc => pc.ProductId == productId  && pc.AdminRead == IsAdminRead.IsTrue)
                .Skip(skip).Take(take)
                .OrderByDescending(pc => pc.CreateDate)
                .AsNoTracking()
                .ToList();
            if (pageCount % 2 != 0)
            {
                pageCount += 1;
            }
            return Tuple.Create(commentsList, pageCount);
        }

        public int GetAllProductComments(int productId)
        {
            return _db.ProductComments.Where(p => p.ProductId == productId && p.AdminRead == IsAdminRead.IsTrue).Count();
        }

        public Tuple<List<ProductComment>,int> ShowAllCommentsForAdmin(IsAdminRead adminRead , int pageId =1)
        {
            int skip = (pageId - 1) * 10;

            int rowsCount = _db.ProductComments.Where(c => c.AdminRead == adminRead).Count() / 10;
            var result = _db.ProductComments
                .OrderBy(c=>c.Id)
                .Where(c => c.AdminRead == adminRead )
                .Skip(skip)
                .Take(10)
                .AsNoTracking()
                .ToList();

            return Tuple.Create(result, rowsCount);
        }

        public void AccessComment(int productId , int commentId)
        {
            try
            {
                var comment = _db.ProductComments.First(p => p.ProductId == productId && p.Id == commentId);

                comment.AdminRead = IsAdminRead.IsTrue;
                _db.Update(comment);
                _db.SaveChanges();

            }
            catch (Exception)
            {
            }
        }

        public void DeleteComment(int productId, int commentId)
        {
            try
            {
                var comment = _db.ProductComments.First(p => p.ProductId == productId && p.Id == commentId);

                comment.IsDelete = true;
                _db.Update(comment);
                _db.SaveChanges();

            }
            catch (Exception)
            {
            }
        }

        public Tuple<List<ProductComment>, int> ShowUserComments(int UserId , int pageId = 1)
        {
            int skip = (pageId - 1) * 10;

            int rowsCount = _db.ProductComments.Where(c => c.UserId == UserId && c.AdminRead == IsAdminRead.IsTrue).Count() / 10;
            var result = _db.ProductComments
                .Include(p=>p.Product)
                .OrderBy(c => c.Id)
                .Where(c => c.AdminRead == IsAdminRead.IsTrue)
                .Skip(skip)
                .Take(10)
                .AsNoTracking()
                .ToList();

            return Tuple.Create(result, rowsCount);
        }
    }
}
