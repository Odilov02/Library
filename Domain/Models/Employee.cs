using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml;

namespace Domain.Models
{
    [Table("employee")]
    public class Employee
    {
        [Column("employe_id")]
        [JsonPropertyName("employe_id")]
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [Column("phone_number")]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }
        [Column("category_id")]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public required Category Category { get; set; }
    }
}
