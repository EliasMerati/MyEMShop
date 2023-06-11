using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyEMShop.Data.Entities.Permission
{
    public class Permission
    {
        public Permission()
        {

        }

        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "نام دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string PermissionTitle { get; set; }
        public int? ParentId { get; set; }


        #region Navigation Property
        [ForeignKey(nameof(ParentId))]
        public virtual IList<Permission> Permissions { get; set; }

        public virtual ICollection<RolePermission> RolePermissions { get; set; }
        #endregion

    }
}
