using MyEMShop.Data.Entities.Permission;
using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Application.Interfaces
{
    public interface IPermissionService
    {
        #region Role
        IList<Role> GetRoles();
        int AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int roleId);
        void SetRoles(IList<int> roleIds, int userId);
        void UpdateRoles(int userId, IList<int> roleIds);
        #endregion

        #region Permission
        IList<Permission> GetAllPermissions();
        void AddPermissionToRole(int roleId, IList<int> Permissions);
        IList<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId , IList<int> Permissions);
        #endregion
    }
}
