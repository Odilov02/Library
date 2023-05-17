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
    [Table("book")]
    public class Book
    {
        [Column("book_id")]
        [JsonPropertyName("book_id")]
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Column("name")]
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("create_date")]
        [Column("create_date")]
        public DateTime CreateDate { get; set; }
        [JsonIgnore]
        IEnumerable<AuthorBook>? AuthorBooks { get; set; }
        [Column("category_id")]
        [JsonPropertyName("category_id")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public required Category Category { get; set; }
    }
}
