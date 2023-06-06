using MyEMShop.Application.Interfaces;
using MyEMShop.Common;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.User;
using System.Collections.Generic;
using System.Linq;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.Application.Services
{
    public class ManageUserService : IManageUserService
    {
        #region Injection Context
        private readonly DatabaseContext _db;
        public ManageUserService(DatabaseContext db)
        {
            _db = db;
        }

        #endregion


        public UserListForAdminDto GetUsers(int pageId = 1, string FilterEmail = "", string FilterUserName = "", string filterName = "", string filterFamily = "")
        {
            IQueryable<User> Result = _db.Users;

            if (FilterEmail is not null)
            {
                Result = Result.Where(u => u.Email.Contains(FilterEmail));
            }

            if (filterName is not null)
            {
                Result = Result.Where(u => u.Email.Contains(filterName));
            }

            if (filterFamily is not null)
            {
                Result = Result.Where(u => u.Email.Contains(filterFamily));
            }

            if (FilterUserName is not null)
            {
                Result = Result.Where(u => u.Email.Contains(FilterUserName));
            }

            int take = 20;
            int skip = (pageId - 1) * take;

            UserListForAdminDto userList = new UserListForAdminDto();
            userList.CurrentPage = pageId;
            userList.Users = Result.OrderBy(u=> u.RegisterDate).Skip(skip).Take(take).ToList();
            userList.PageCount = Result.Count() / take;
            return userList;
        }


        public int AddUserByAdmin(CreateUserWithadminDto create)
        {
            var user = new User();
            user.Password = PasswordHelper.EncodePasswordMd5(create.Password);
            user.Email = create.Email;
            user.UserName= create.UserName;
            user.Activecode = GenerateCode.GenerateUniqueCode();
            user.IsActive = true;
            user.Name= create.Name;
            user.Family= create.Family;
            user.RegisterDate = System.DateTime.Now;

            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserId;
        }
    }
}
