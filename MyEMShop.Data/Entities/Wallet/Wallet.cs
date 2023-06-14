using System;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Wallet
{
    public class Wallet
    {
        public Wallet()
        {

        }

        [Key]
        public int WalletId { get; set; }

        [Display(Name = "نوع تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int TypeId { get; set; }

        [Display(Name = "کاربر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int UserId { get; set; }

        [Display(Name = "مبلغ تراکنش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int Amount { get; set; }

        [Display(Name = "تایید پرداخت")]
        public bool IsPay { get; set; }

        [Display(Name = "توضیحات")]
        [MaxLength(300)]
        public string Description { get; set; }

        [Display(Name = "تاریخ ثبت تراکنش")]
        public DateTime CreateDate { get; set; }

        #region Relations
        public virtual User.User User { get; set; }
        public WalletType WalletType { get; set; }
        #endregion
    }
}
