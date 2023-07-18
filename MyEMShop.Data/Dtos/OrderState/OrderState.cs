using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Dtos.OrderState
{
    public enum OrderState
    {
        [Display(Name = "در حال آماده سازی")]
        InProgress = 0,

        [Display(Name = "لغو شده")]
        IsCanceled = 1,

        [Display(Name = "آماده ارسال")]
        IsDone =2,

        [Display(Name = "ارسال شده")]
        IsSend = 3
    }
}
