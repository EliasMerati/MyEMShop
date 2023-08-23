using Microsoft.EntityFrameworkCore;
using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Faq;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{

    public class FaqService : IFaqService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public FaqService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion


        public void AddFaq(Faq faq)
        {
            try
            {
                _db.Add(faq);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }

        }

        public void DeleteFaq(int faqId)
        {
            try
            {
                var faq = GetFaqById(faqId);
                _db.Remove(faq);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }

        }

        public Faq GetFaqById(int faqId)
        {
            return _db.Faqs.Find(faqId);
        }

        public List<Faq> GetFaqList()
        {
            return _db.Faqs
                .Include(f => f.FaqGroup)
                .ToList();
        }

        public void UpdateFaq(Faq faq)
        {
            try
            {
                _db.Update(faq);
                _db.SaveChanges();
            }
            catch (System.Exception)
            {
            }

        }
    }
}
