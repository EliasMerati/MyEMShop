using MyEMShop.Data.Entities.ContactUs;
using System.Collections.Generic;

namespace MyEMShop.Application.Interfaces
{
    public interface IContactUsConnectionService
    {
        List<ContactUsConection> GetContactUsConnections();
        void AddContactUsConnection(ContactUsConection contactUsConection);
        void RemoveContactUsConnection(int CUC_Id);
    }
}
