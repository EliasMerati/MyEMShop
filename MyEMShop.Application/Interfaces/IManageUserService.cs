using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Application.Interfaces
{
    public interface IManageUserService
    {
        IList<User> GetUsers(int pageId=1 , string FilterEmail = "" , string FilterUserName = "");
    }
}
