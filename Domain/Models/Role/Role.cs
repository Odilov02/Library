using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public IEnumerable<RolePermission>? RolePermissions { get; set; }
        [JsonIgnore]
        public IEnumerable<RoleUser>? RoleUsers { get; set; }
    }
}
