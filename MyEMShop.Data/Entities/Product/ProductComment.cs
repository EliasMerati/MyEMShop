using MyEMShop.Data.Dtos.IsRead;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Product
{
    public class ProductComment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [MaxLength(700)]
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDelete { get; set; }
        public IsAdminRead AdminRead { get; set; }

        #region Relations
        public Product Product { get; set; }
        public User.User User { get; set; }
        #endregion
    }
}
