using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.ContactUs
{
    public class ContactUsInfo
    {
        [Key]
        public int ContactUsInfoId { get; set; }

        [MaxLength(50)]
        public string ContactUsAddress { get; set; }

        [MaxLength(50)]
        public string ContactUsOstanCity { get; set; }

        [MaxLength(50)]
        public string ContactUsPelak { get; set; }

        [MaxLength(50)]
        public string ContactUsPhone { get; set; }

        [MaxLength(100)]
        public string ContactUsWorkTime { get; set; }

        [MaxLength(200)]
        public string ContactUsImage { get; set; }

        [MaxLength(500)]
        public string ContactUsDesc { get; set; }

    }
}
