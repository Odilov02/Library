using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public IEnumerable<RolePermission>? rolePermissions { get; set; }

    }
}
