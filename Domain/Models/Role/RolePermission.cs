using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Roles
{
    [Table("role_permission")]
    public class RolePermission
    {
        [Column("role_permission_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("role_id")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [Column("permission_id")]
        public int PermissionId { get; set; }
        public Permission permission { get; set; }
    }
}
