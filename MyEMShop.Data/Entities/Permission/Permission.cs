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

        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PermissionId { get; set; }

        [Display(Name = "نام دسترسی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        public string PermissionTitle { get; set; }
        public int? ParentId { get; set; }


        #region Navigation Property
        [ForeignKey(nameof(ParentId))]
        public ICollection<Permission> Permissions { get; set; }

        public ICollection<RolePermission> RolePermissions { get; set; }
        #endregion

    }
}
