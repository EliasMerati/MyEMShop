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
        IList<Role> GetRoles();
        int AddRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role GetRoleById(int roleId);
        void SetRoles(IList<int> roleIds , int userId);
        void UpdateRoles(int userId, IList<int> roleIds);
    }
}
