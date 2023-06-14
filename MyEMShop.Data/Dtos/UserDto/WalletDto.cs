using System;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Dtos.UserDto
{
    public record ChargeWalletDto
    {
        [Display(Name = "مبلغ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }
    }

    public record ShowWalletDto
    {
        public int Amount { get; set; }

        public int TypeId { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
