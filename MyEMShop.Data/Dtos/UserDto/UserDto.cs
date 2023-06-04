using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Data.Dtos.UserDto
{
    public class UserDto
    {
        public class UserListForAdminDto
        {
            public IList<User> Users { get; set; }
            public int CurrentPage { get; set; }
            public int PageCount { get; set; }
        }
    }
}
