using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Faq
{
    public class FaqGroup
    {
        [Key]
        public int FaqGroupId { get; set; }

        [Display(Name = "گروه سوالات")]
        [MaxLength(100)]
        [Required]
        public string FaqGroupTitle { get; set; }

        #region Relation
        public ICollection<Faq> Faqs { get; set; }
        #endregion
    }
}
