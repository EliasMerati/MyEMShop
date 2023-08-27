﻿using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.ContactUs;
using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class ContactUsConnectionService : IContactUsConnectionService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        private readonly IViewRenderService _viewRender;
        public ContactUsConnectionService(DatabaseContext db, IViewRenderService viewRender)
        {
            _db = db;
            _viewRender = viewRender;
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
                SendEmail.Send(Email, "پاسخ ایمیل ارسالی", body);
            }
            catch (Exception)
            {
            }
           
        }

        public ContactUsConection GetById(int CUC_Id)
        {
            return _db.contactUsConections.Find(CUC_Id);
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
