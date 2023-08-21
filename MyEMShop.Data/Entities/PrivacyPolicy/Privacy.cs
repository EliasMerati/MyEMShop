using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.PrivacyPolicy
{
    public class Privacy
    {
        [Key]
        public int PrivacyId { get; set; }
        public string PrivacyText { get; set; }
    }
}
