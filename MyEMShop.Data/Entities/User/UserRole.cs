using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEMShop.Data.Entities.User
{
    public class UserRole
    {
        public UserRole()
        {

        }

        [Key]
        public int UserroleId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        #region Relations
        public virtual User User { get; set; }
        public virtual Role Role { get; set; }
        #endregion
    }
}
