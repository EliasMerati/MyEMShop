using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.ContactUs
{
    public class ContactUsConection
    {
        [Key]
        public int CUC_Id { get; set; }

        [Display(Name = "ایمیل شخص")]
        [EmailAddress]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string Email { get; set; }

        [Display(Name = "نام شخص")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50)]
        public string name { get; set; }

        [Display(Name = "متن سوال")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        public string Question { get; set; }
    }
}
