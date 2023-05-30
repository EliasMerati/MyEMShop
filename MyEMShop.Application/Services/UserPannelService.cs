using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.UserDto;
using System;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class UserPannelService : IUserPannelService
    {
        private readonly DatabaseContext _db;
        public UserPannelService(DatabaseContext db)
        {
            _db = db;
        }

        public void EditUserPannel(string userName, ShowUserInfoForEditPannelDto edit)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);

            user.Address = edit.Address;
            user.PhoneNumber = edit.PhoneNumber;
            user.Ostan = edit.Ostan;
            user.City = edit.City;
            user.PostalCode = edit.PostalCode;
            user.Name= edit.Name;
            user.Family= edit.Family;

            //_db.Update(user);
            _db.SaveChanges();

        }

        public ShowUserInfoForEditPannelDto GetInfoForEdit(string userName)
        {
            return _db.Users.Where(u => u.UserName == userName).Select(u => new ShowUserInfoForEditPannelDto
            {
                Address= u.Address,
                City= u.City,
                Family= u.Family,
                Name= u.Name,
                Ostan = u.Ostan,
                PhoneNumber= u.PhoneNumber,
                PostalCode= u.PostalCode, 
            }).Single();
        }

        public ShowUserInformationForPannelDto GetUserInfo(string userName)
        {
          var user = _db.Users.SingleOrDefault(u => u.UserName == userName);
            ShowUserInformationForPannelDto info = new ShowUserInformationForPannelDto();
            info.Ostan = user.Ostan;
            info.Email = user.Email;
            info.City = user.City;
            info.Address = user.Address;
            info.PhoneNumber = user.PhoneNumber;
            info.Family = user.Family;
            info.Name = user.Name;
            info.PostalCode = user.PostalCode;

            return info;
        }

        public string HashPassword(string password)
        {
            return PasswordHelper.EncodePasswordMd5(password);
        }

        public void ChangeNewPassword(string username, string password)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == username);
            user.Password = HashPassword(password);
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public bool CompareOldPassword(string password, string username)
        {
            var HashPass = HashPassword(password);
            return _db.Users.Any(u => u.UserName == username && u.Password == HashPass);
        }
    }
}
