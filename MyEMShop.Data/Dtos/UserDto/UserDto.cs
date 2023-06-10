using MyEMShop.Data.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public class CreateUserWithadminDto
        {
            [Display(Name = "نام کاربری")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(150)]
            public string UserName { get; set; }

            [Display(Name = "ایمیل")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(150)]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "کلمه عبور")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(200)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "نام")]
            [MaxLength(150)]
            public string Name { get; set; }

            [Display(Name = "نام خانوادگی")]
            [MaxLength(150)]
            public string Family { get; set; }

            //public IList<int> SelectedRoles { get; set; }
        }

        public class EditUserWithAdminDto
        {
            public int UserId { get; set; }
            public string UserName { get; set; }

            [Display(Name = "ایمیل")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(150)]
            [EmailAddress]
            public string Email { get; set; }

            [Display(Name = "کلمه عبور")]
            [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
            [MaxLength(200)]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Display(Name = "نام")]
            [MaxLength(150)]
            public string Name { get; set; }

            [Display(Name = "نام خانوادگی")]
            [MaxLength(150)]
            public string Family { get; set; }

            public IList<int> UserRoles { get; set; }
        }
    }
}
