using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalaMarket.DataLayer.Entities.Role
{
    public class RolePermission
    {
        [Key]
        public int RolePermissionId { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        #region relation

        [ForeignKey(nameof(RoleId))]
        public Role role { get; set; }

        [ForeignKey(nameof(PermissionId))]
        public Permission permission { get; set; }
        #endregion
    }
}
