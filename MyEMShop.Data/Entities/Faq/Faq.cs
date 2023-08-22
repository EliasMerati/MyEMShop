using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Data.Entities.Faq
{
    public class Faq
    {
        [Key]
        public int FaqId { get; set; }
        public int FaqGroupId { get; set; }

        [Display(Name ="سوال")]
        [MaxLength(300)]
        public string FaqQuestion { get; set;}

        [Display(Name = "جواب")]
        [MaxLength(500)]
        public string FaqAnswer { get; set;}

        #region Relation
        public FaqGroup FaqGroup { get; set; }
        #endregion
    }
}
