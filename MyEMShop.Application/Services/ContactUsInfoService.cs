using Microsoft.AspNetCore.Http;
using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.ContactUs;
using System;
using System.IO;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class ContactUsInfoService : IContactUsInfoService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public ContactUsInfoService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile)
        {
            try
            {
                AddImageForContactUsInfo(contactUsInfo, ImgFile);
                _db.Add(contactUsInfo);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void AddImageForContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile)
        {
            if (ImgFile is not null)
            {
                contactUsInfo.ContactUsImage = GenerateCode.GenerateUniqueCode() + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/ContactUsInfo/", contactUsInfo.ContactUsImage);
                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
            }
        }

        public void EditContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile)
        {
            try
            {
                EditImageForContactUsInfo(contactUsInfo, ImgFile);
                _db.Update(contactUsInfo);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void EditImageForContactUsInfo(ContactUsInfo contactUsInfo, IFormFile ImgFile)
        {
            if (ImgFile is not null && ImgFile.IsImage())
            {
                string DeleteImagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/ContactUsInfo/", contactUsInfo.ContactUsImage);
                if (File.Exists(DeleteImagePath))
                {
                    File.Delete(DeleteImagePath);
                }
                contactUsInfo.ContactUsImage = GenerateCode.GenerateUniqueCode() + Path.GetExtension(ImgFile.FileName);
                string Imagepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Template/image/ContactUsInfo/", contactUsInfo.ContactUsImage);
                using (var stream = new FileStream(Imagepath, FileMode.CreateNew))
                {
                    ImgFile.CopyTo(stream);
                }
            }
        }

        public ContactUsInfo GetContactUsInfo()
        {
            return _db.ContactUsInfos.FirstOrDefault();
        }

        public ContactUsInfo GetContactUsInfoById(int contactUsInfoId)
        {
            return _db.ContactUsInfos.Find(contactUsInfoId);
        }

        public bool IsExistContactUsInfo()
        {
            return _db.ContactUsInfos.Any();
        }
    }
}
