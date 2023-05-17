using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Roles
{
    [Table("role")]
    public class Role
    {
        [Column("role_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("role_name")]
        public string Name { get; set; }
        [Column("role_permission_id")]
        public int RolePermissionId { get; set; }
        public IEnumerable<RolePermission> RolePermissions { get; set; }
        [Column("role_user_id")]
        public int RoleUSerId { get; set; }
        public IEnumerable<RoleUser> RoleUsers { get; set; }
    }
}
