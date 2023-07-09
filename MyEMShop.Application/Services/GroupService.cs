﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class GroupService : IGroupService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public GroupService(DatabaseContext db)
        {
            _db = db;
        }

        #endregion

        public void AddGroup(ProductGroup group)
        {
            _db.Add(group);
            _db.SaveChanges();
        }

        public void UpdateGroup(ProductGroup group)
        {
            _db.Update(group);
            _db.SaveChanges();
        }

        public List<ProductGroup> GetGroups()
        {
            return _db.ProductGroups.Include(p => p.Groups).ToList();
        }

        public IList<SelectListItem> GetGroupsForManageProduct()
        {
            return _db.ProductGroups
                .Where(p => p.ParentId == null)
                .Select(p => new SelectListItem
                {
                    Value = p.GroupId.ToString(),
                    Text = p.GroupTitle,
                })
                .ToList();
        }

        public IList<SelectListItem> GetSubGroupsForManageProduct(int groupId)
        {
            return _db.ProductGroups
                .Where(p => p.ParentId == groupId)
                .Select(p => new SelectListItem
                {
                    Value = p.GroupId.ToString(),
                    Text = p.GroupTitle,
                })
                .ToList();
        }
    }
}
