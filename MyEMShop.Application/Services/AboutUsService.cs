using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.AboutUs;
using System;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class AboutUsService : IAboutUsService
    {

        #region Inject Database
        private readonly DatabaseContext _db;
        public AboutUsService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion

        public void AddAboutUs(AboutUs aboutUs)
        {
            try
            {
                _db.Add(aboutUs);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public void EditAboutUs(AboutUs aboutUs)
        {
            try
            {
                _db.Update(aboutUs);
                _db.SaveChanges();
            }
            catch (Exception)
            {
            }
        }

        public AboutUs GetAboutUs()
        {
            return _db.AboutUs.FirstOrDefault();
        }

        public AboutUs GetAboutUsById(int aboutUsId)
        {
            return _db.AboutUs.Find(aboutUsId);
        }

        public bool IsAboutUsExist()
        {
            return _db.AboutUs.Any();
        }
    }
}
