using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.User;
using System.Collections.Generic;
using System.Linq;

namespace MyEMShop.Application.Services
{
    public class PermissionService : IPermissionService
    {
        #region Inject context
        private readonly DatabaseContext _db;
        public PermissionService(DatabaseContext db)
        {
            _db = db;
        }
        #endregion


        public IList<Role> GetRoles()
        {
            return _db.Roles.ToList();
        }

        public void SetRoles(IList<int> roleIds, int userId)
        {
            foreach (var roleId in roleIds)
            {
                _db.UserRoles.Add(new UserRole
                {
                    RoleId = roleId,
                    UserId = userId,
                });
            }
            _db.SaveChanges();
        }
    }
}
