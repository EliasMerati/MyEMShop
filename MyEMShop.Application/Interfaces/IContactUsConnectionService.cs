using MyEMShop.Data.Entities.ContactUs;
using System;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IContactUsConnectionService
    {
        Tuple<List<ContactUsConection>, int> GetContactUsConnections(int pageId = 1);
        void AddContactUsConnection(ContactUsConection contactUsConection);
        void RemoveContactUsConnection(int CUC_Id);
        ContactUsConection GetById(int CUC_Id);
        void AnswerQuestion( string answer , string Email);

    }
}
