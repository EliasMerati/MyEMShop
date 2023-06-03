using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


        public IList<User> GetUsers(int pageId = 1, string FilterEmail = "", string FilterUserName = "")
        {
            IQueryable<User> Result = _db.Users;
        }
    }
}
