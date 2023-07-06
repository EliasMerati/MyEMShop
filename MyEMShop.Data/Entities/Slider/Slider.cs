using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Slider
{
    public class Slider
    {
        [Key]
        public int SliderId { get; set; }

        [Display(Name = "عکس بنر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(150)]
        public string SliderImageName { get; set; }
    }
}
