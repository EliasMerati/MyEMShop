using Microsoft.EntityFrameworkCore;
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
            IQueryable<User> Result = _db.Users.Where(u=> !u.IsDelete);

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
            userList.Users = Result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            userList.PageCount = Result.Count() / take;
            return userList;
        }


        public int AddUserByAdmin(CreateUserWithadminDto create)
        {
            var user = new User();
            user.Password = PasswordHelper.EncodePasswordMd5(create.Password);
            user.Email = create.Email;
            user.UserName = create.UserName;
            user.Activecode = GenerateCode.GenerateUniqueCode();
            user.IsActive = true;
            user.Name = create.Name;
            user.Family = create.Family;
            user.RegisterDate = System.DateTime.Now;

            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserId;
        }

        public EditUserWithAdminDto ShowUserInfoForEditWithAdmin(int userId)
        {
            return _db.Users.Where(u => u.UserId == userId)
                .Select(u => new EditUserWithAdminDto
                {
                    UserId = u.UserId,
                    UserRoles = GetCurrentRoles(userId),
                    Email = u.Email,
                    UserName = u.UserName,
                    Family = u.Family,
                    Name = u.Name,
                }).Single();

        }

        public IList<int> GetCurrentRoles(int userid)
        {
            return _db.UserRoles.Where(u => u.UserId == userid)
                .Select(r => r.RoleId)
                  .ToList();
        }

        public void EditUserByAdmin(EditUserWithAdminDto edit)
        {
            var user = FindUserByUserId(edit.UserId);
            if (edit.Password is not null) { user.Password = PasswordHelper.EncodePasswordMd5(edit.Password); }
            user.Email= edit.Email;
            user.Name= edit.Name;
            user.Family= edit.Family;
            _db.Users.Update(user);
            _db.SaveChanges();
        }

        public User FindUserByUserId(int userId)
        {
            return _db.Users.Find(userId);
        }

        public UserListForAdminDto GetDeleteUsers(int pageId = 1, string FilterEmail = "", string FilterUserName = "", string filterName = "", string filterFamily = "")
        {
            IQueryable<User> Result = _db.Users.IgnoreQueryFilters().Where(u=>u.IsDelete);

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
            userList.Users = Result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            userList.PageCount = Result.Count() / take;
            return userList;
        }

        public void DeleteUser(int userId)
        {
            var user = FindUserByUserId(userId);
            user.IsDelete = true;
            _db.Update(user);
            _db.SaveChanges();
        }

        public void ReturnUser(int userId)
        {
            var user = FindUserByUserId(userId);
            user.IsDelete = false;
            _db.Update(user);
            _db.SaveChanges();
        }
    }
}
