using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.User;
using System;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly DatabaseContext _db;
        public AccountServices(DatabaseContext db)
        {
            _db = db;
        }

        public bool IsExistEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);  
        }

        public bool IsExistUserName(string userName)
        {
           return _db.Users.Any(u => u.UserName == userName);
        }

        public bool Register(User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
