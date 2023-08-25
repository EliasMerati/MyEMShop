using MyEMShop.Application.Interfaces;
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

        public List<ContactUsConection> GetContactUsConnections()
        {
            return _db.contactUsConections.ToList();
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
