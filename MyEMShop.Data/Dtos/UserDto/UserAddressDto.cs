using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Dtos.UserDto
{
    public record UserAddressDto
    {

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
    }
}
