using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Models
{
    [Table("user")]
    public class Users
    {
        [Column("user_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("password")]
        public string Password { get; set; }
        [EmailAddress]
        [Column("email")]
        public string Email { get; set; }
        [JsonIgnore]
        public IEnumerable<RoleUser>? RoleUsers { get; set; }
    }
}
