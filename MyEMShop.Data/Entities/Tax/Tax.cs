using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Tax
{
    public class Tax
    {
        [Key]
        public int TaxId { get; set; }
        public int? TaxValue { get; set; }
    }
}
