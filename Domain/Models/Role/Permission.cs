using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Roles
{
    [Table("permission")]
    public class Permission
    {
        [Column("permission_id")]
        public int Id { get; set; }
        [Column("permission_name")]
        public string Name {get; set;}
        [Column("role_permission_id")]
        public int RolePermissionId { get; set; }
        public IEnumerable<RolePermission> rolePermissions { get; set; }

    }
}
