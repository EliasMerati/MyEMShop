using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.AboutUs
{
    public class AboutUs
    {
        [Key]
        public int AboutUsId { get; set; }
        public string AboutUsText { get; set; }
    }
}
