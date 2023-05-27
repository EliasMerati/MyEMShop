using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.UserDto;
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

        public bool ActiveAccount(string activeCode)
        {
            var user = _db.Users.FirstOrDefault(u=> u.Activecode== activeCode);
            if (user == null || user.IsActive) { return false; }
            user.IsActive = true;
            user.Activecode = GenerateCode.GenerateUniqueCode();
            _db.SaveChanges();
            return true;
        }

        public void ChangeNewPassword(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u=> u.UserName == username);
            user.Password = HashPassword(password);
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public bool CompareOldPassword(string password, string username)
        {
            var HashPass = HashPassword(password);
            return _db.Users.Any(u=> u.UserName == username && u.Password == HashPass);
        }

        public User GetUserByEmail(string email)
        {
            return _db.Users.SingleOrDefault(u => u.Email == email);
        }

        public string HashPassword(string password)
        {
            return PasswordHelper.EncodePasswordMd5(password);
        }

        public bool IsExistEmail(string email)
        {
            return _db.Users.Any(u => u.Email == email);  
        }

        public bool IsExistUserName(string userName)
        {
           return _db.Users.Any(u => u.UserName == userName);
        }

        public User LoginUser(LoginDto login)
        {
            string HashPass = HashPassword(login.Password);
            string email = FixedEmail.Fix(login.Email);
            return _db.Users.SingleOrDefault(u => u.Email == email && u.Password == HashPass);
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
