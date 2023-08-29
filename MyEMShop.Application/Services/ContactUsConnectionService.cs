using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.ContactUs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class ContactUsConnectionService : IContactUsConnectionService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public ContactUsConnectionService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddContactUsConnection(ContactUsConection contactUsConection)
        {
            try
            {
                _db.Add(contactUsConection);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void AnswerQuestion(string answer, string Email)
        {
            try
            {
                var body = answer;
                SendEmail.Send(Email, "ارسال پاسخ", body);
            }
            catch (Exception)
            {
            }

        }

        public ContactUsConection GetById(int CUC_Id)
        {
            return _db.contactUsConections.Find(CUC_Id);
        }

        public Tuple<List<ContactUsConection>, int> GetContactUsConnections(int pageId = 1)
        {
            int skip = (pageId - 1) * 10;
            int rowscount = _db.contactUsConections.Count() / 10;
            var result = _db.contactUsConections
                .Skip(skip)
                .Take(10)
                .ToList();
            return Tuple.Create(result, rowscount);
        }

        public void RemoveContactUsConnection(int CUC_Id)
        {
            try
            {
                var connection = _db.contactUsConections.Find(CUC_Id);
                _db.Remove(connection);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }
    }
}
