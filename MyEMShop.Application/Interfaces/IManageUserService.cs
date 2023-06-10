using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyEMShop.Data.Dtos.UserDto.UserDto;

namespace MyEMShop.Application.Interfaces
{
    public interface IManageUserService
    {
        UserListForAdminDto GetUsers(int pageId=1 , string FilterEmail = "" , string FilterUserName = "", string filterName = "", string filterFamily = "");
        UserListForAdminDto GetDeleteUsers(int pageId = 1, string FilterEmail = "", string FilterUserName = "", string filterName = "", string filterFamily = "");
        int AddUserByAdmin(CreateUserWithadminDto create);
        IList<int> GetCurrentRoles(int userid);
        EditUserWithAdminDto ShowUserInfoForEditWithAdmin(int userId);
        void EditUserByAdmin(EditUserWithAdminDto edit);
        User FindUserByUserId(int userId);
    }
}
