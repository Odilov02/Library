using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Tokens
{
    [Table("refresh_token")]
    public class RefreshToken
    {
        [Column("token_id")]
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("user_name")]
        public string? UserName { get; set; }
        [Column("token")]
        public string? Token { get; set; }
        [Column("active_date")]
        public DateTime ActiveDate { get; set; }
    }
}
