using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Terms
{
    public class Term
    {
        [Key]
        public int TermId { get; set; }
        public string TermDescription { get; set; }
    }
}
