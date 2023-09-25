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

        public User GetUserByActiveCode(string activeCode)
        {
            return _db.Users.FirstOrDefault(u=> u.Activecode == activeCode);    
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

        public void UpdateUser(User user)
        {
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public bool IsAdmin(string email)
        {
            return _db.UserRoles
                .Any(u => u.User.Email == email && u.RoleId == 1);
        }
    }
}
