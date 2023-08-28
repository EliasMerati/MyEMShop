using Microsoft.AspNetCore.Http;
using MyEMShop.Data.Entities.ContactUs;

namespace MyEMShop.Application.Interfaces
{
    public interface IContactUsInfoService
    {
        ContactUsInfo GetContactUsInfo();
        ContactUsInfo GetContactUsInfoById(int contactUsInfoId);
        void AddContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile);
        void EditContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile);
        void AddImageForContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile);
        void EditImageForContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile);
    }
}
