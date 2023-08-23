using Microsoft.AspNetCore.Mvc.Rendering;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class FaqGroupService : IFaqGroupService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public FaqGroupService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddFaqGroup(FaqGroup faqGroup)
        {
            try
            {
                _db.Add(faqGroup);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
           
        }

        public void DeleteFaqGroup(int faqGroupId)
        {
            try
            {
                var faqGroup = GetFaqGroupById(faqGroupId);
                _db.Remove(faqGroup);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
            
        }

        public List<SelectListItem> GetAllFaqGroupForFaq()
        {
            return _db.FaqGroups
                 .Select(p => new SelectListItem
                 {
                     Value = p.FaqGroupId.ToString(),
                     Text = p.FaqGroupTitle,
                 }).ToList();
        }

        public FaqGroup GetFaqGroupById(int faqGroupId)
        {
            return _db.FaqGroups.Find(faqGroupId);
        }

        public List<FaqGroup> GetFaqGroups()
        {
            return _db.FaqGroups
                .ToList();
        }

        public void UpdateFaqGroup(FaqGroup faqGroup)
        {
            try
            {
                _db.FaqGroups.Update(faqGroup);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }
           
        }
    }
}
