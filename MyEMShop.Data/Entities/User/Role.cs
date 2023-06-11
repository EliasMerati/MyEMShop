using MyEMShop.Data.Entities.Permission;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEMShop.Data.Entities.User
{
    public class Role
    {
        public Role()
        {

        }

        [Key]  
        public int RoleId { get; set; }

        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string RoleTitle { get; set; }

        public bool IsDelete { get; set; }



        #region Navigation Property
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        #endregion
    }
}
