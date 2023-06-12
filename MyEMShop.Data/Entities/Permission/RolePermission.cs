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
        public Role Role { get; set; }
        public Permission Permission { get; set; }
        #endregion
    }
}
