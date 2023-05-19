using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Domain.Models.Roles;

namespace Domain.Models;

[Table("role_user")]
public class RoleUser
{
    [Column("role_user_id")]
    [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Column("role_id")]
    public int RoleId { get; set; }
    [JsonIgnore]
    public  Role? Role { get; set; }
    [Column("users_id")]
    public int UsersId { get; set; }
    [JsonIgnore]
    public Users? Users { get; set; }
}
