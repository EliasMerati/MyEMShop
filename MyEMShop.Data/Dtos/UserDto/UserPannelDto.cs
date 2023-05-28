using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Dtos.UserDto
{
    public class ShowUserInformationForPannelDto
    {
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

        [Display(Name = "ایمیل")]
        [MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "کد پستی")]
        public string PostalCode { get; set; }
    }
}
