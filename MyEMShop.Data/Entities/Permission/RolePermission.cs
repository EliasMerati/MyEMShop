using MyEMShop.Data.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace MyEMShop.Data.Entities.Permission
{
    public class RolePermission
    {
        public RolePermission()
        {

        }

        [Key]
        public int RP_Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region Navigation Property
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
        #endregion
    }
}
