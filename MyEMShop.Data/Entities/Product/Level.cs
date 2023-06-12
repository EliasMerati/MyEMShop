using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class Level
    {
        [Key]
        public int PL_Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string PL_Title { get; set; }

        #region Navigation Property
        public ICollection<ProductLevel> ProductLevels { get; set; }
        #endregion
    }
}
