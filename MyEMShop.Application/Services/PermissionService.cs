using MyEMShop.Application.Interfaces;
using MyEMShop.Data.Context;
using MyEMShop.Data.Entities.Permission;
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


        public int AddRole(Role role)
        {
            _db.Add(role);
            _db.SaveChanges();
            return role.RoleId;
        }

        public void AddPermissionToRole(int roleId, IList<int> Permissions)
        {
            foreach (var p in Permissions)
            {
                _db.RolePermission.Add(new RolePermission 
                {
                    RoleId = roleId,
                    PermissionId = p,
                }); 
            }
            _db.SaveChanges();
        }
        public void DeleteRole(Role role)
        {
            role.IsDelete = true;
            UpdateRole(role);
        }

        public IList<Permission> GetAllPermissions()
        {
            return _db.Permission.ToList();
        }

        public Role GetRoleById(int roleId)
        {
            return _db.Roles.Find(roleId);
        }

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

        public void UpdateRole(Role role)
        {
            _db.Update(role);
            _db.SaveChanges();
        }

        public void UpdateRoles( int userId, IList<int> roleIds)
        {
            //Delete All Roles
            _db.UserRoles.Where(r => r.UserId == userId)
                .ToList()
                .ForEach(r => _db.UserRoles.Remove(r));

            // Add New roles
            SetRoles(roleIds,userId);
        }

        public IList<int> PermissionsRole(int roleId)
        {
            return _db.RolePermission
                .Where(r=> r.RoleId == roleId)
                .Select(r=> r.PermissionId)
                .ToList();
        }

        public void UpdatePermissionsRole(int roleId, IList<int> Permissions)
        {
            _db.RolePermission
                .Where(p=> p.RoleId == roleId)
                .ToList()
                .ForEach(p=> _db.RolePermission.Remove(p));

            AddPermissionToRole(roleId, Permissions);
        }
    }
}
