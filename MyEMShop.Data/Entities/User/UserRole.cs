using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {

        }

        [Key]
        public int U_RId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Relations
        public User User { get; set; } = null!;
        public Role Role { get; set; } = null!;
        #endregion
    }
}
