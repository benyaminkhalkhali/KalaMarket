using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Role
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }
        public string PermissionTitle { get; set; }

        #region relation
        public List<RolePermission> rolePermissions { get; set; }
        #endregion
    }
}
