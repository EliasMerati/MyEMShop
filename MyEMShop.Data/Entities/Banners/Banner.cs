using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Banners
{
    public class Banner
    {
        [Key]
        public int BannerId { get; set; }

        [Display(Name ="نام بنر")]
        [MaxLength(50)]
        public string BannerName { get; set; }

        [Display(Name = "عکس بنر")]
        [MaxLength(200)]
        public string BannerImage { get; set; }

        [Display(Name = "لینک بنر")]
        [MaxLength(100)] 
        public string BannerLink { get; set; }
    }
}
