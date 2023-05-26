using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
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

        public void ChangeNewPassword(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u=> u.UserName == username);
            user.Password = PasswordHelper.EncodePasswordMd5(password);
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public bool CompareOldPassword(string password, string username)
        {
            var HashPassword = PasswordHelper.EncodePasswordMd5(password);
            return _db.Users.Any(u=> u.UserName == username && u.Password == HashPassword);
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
