using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Dtos.UserDto;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class UserPannelService : IUserPannelService
    {
        #region Inject Database
        private readonly DatabaseContext _db;
        public UserPannelService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion


        public void EditUserPannel(string userName, ShowUserInfoForEditPannelDto edit)
        {
            var user = _db.Users.FirstOrDefault(u => u.UserName == userName);

            user.Address = edit.Address;
            user.PhoneNumber = edit.PhoneNumber;
            user.Ostan = edit.Ostan;
            user.City = edit.City;
            user.PostalCode = edit.PostalCode;
            user.Name = edit.Name;
            user.Family = edit.Family;

            //_db.Update(user);
            _db.SaveChanges();

        }

        public ShowUserInfoForEditPannelDto GetInfoForEdit(string userName)
        {
            return _db.Users.Where(u => u.UserName == userName).Select(u => new ShowUserInfoForEditPannelDto
            {
                Address = u.Address,
                City = u.City,
                Family = u.Family,
                Name = u.Name,
                Ostan = u.Ostan,
                PhoneNumber = u.PhoneNumber,
                PostalCode = u.PostalCode,
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
            info.Wallet = BalanceWallet(userName);
            return info;
        }

        public int GetUserIdByUserName(string userName)
        {
            return _db.Users.Single(u => u.UserName == userName).UserId;
        }
        public int BalanceWallet(string userName)
        {
            int userid = GetUserIdByUserName(userName);
            var Deposit = _db.Wallets.Where(w => w.UserId == userid && w.TypeId == 1 && w.IsPay)
                .Select(w => w.Amount)
                .ToList();
            var Whitdraw = _db.Wallets.Where(w => w.UserId == userid && w.TypeId == 2)
                .Select(w => w.Amount)
                .ToList();

            return Deposit.Sum() - Whitdraw.Sum();
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

        public ShowUserInformationForPannelDto GetUserInfo(int userId)
        {
            var user = _db.Users.SingleOrDefault(u => u.UserId == userId && !u.IsDelete);
            ShowUserInformationForPannelDto info = new ShowUserInformationForPannelDto();
            info.Ostan = user.Ostan;
            info.Email = user.Email;
            info.City = user.City;
            info.Address = user.Address;
            info.PhoneNumber = user.PhoneNumber;
            info.Family = user.Family;
            info.Name = user.Name;
            info.PostalCode = user.PostalCode;
            info.Wallet = BalanceWallet(user.UserName);
            return info;
        }
        public ShowUserInformationForPannelDto GetUserRefreshInfo(int userId)
        {
            var user = _db.Users.Single(u=> u.UserId == userId && u.IsDelete);
            ShowUserInformationForPannelDto info = new ShowUserInformationForPannelDto();
            info.Ostan = user.Ostan;
            info.Email = user.Email;
            info.City = user.City;
            info.Address = user.Address;
            info.PhoneNumber = user.PhoneNumber;
            info.Family = user.Family;
            info.Name = user.Name;
            info.PostalCode = user.PostalCode;
            info.Wallet = BalanceWallet(user.UserName);
            return info;
        }
    }
}
