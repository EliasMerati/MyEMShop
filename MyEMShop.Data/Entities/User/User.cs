using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEMShop.Data.Entities.User
{
    public class User
    {
        public User()
        {

        }

        [Key]
        public int UserId { get; set; }

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

        [Display(Name = "کد فعالسازی")]
        [MaxLength(100)]
        public string Activecode { get; set; }

        [Display(Name = "فعال / غیر فعال")]
        public bool IsActive { get; set; }

        [Display(Name = "نام")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [MaxLength(150)]
        public string Family { get; set; }

        [Display(Name = "شماره تماس")]
        [MaxLength(150)]
        public string PhoneNumber { get; set; }

        [Display(Name = "شهر")]
        [MaxLength(100)]
        public string City { get; set; }

        [Display(Name = "استان")]
        [MaxLength(100)]
        public string Ostan { get; set; }

        [Display(Name = "آدرس محل سکونت")]
        public string Address { get; set; }

        [Display(Name = "کد پستی")]
        public string PostalCode { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime  RegisterDate { get; set; }



        #region Navigation Property
        public virtual ICollection<Wallet.Wallet> Wallets { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        #endregion
    }
}
