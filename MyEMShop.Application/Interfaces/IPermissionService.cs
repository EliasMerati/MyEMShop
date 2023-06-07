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
        void SetRoles(IList<int> roleIds , int userId);
        void UpdateRoles(int userId, IList<int> roleIds);
    }
}
