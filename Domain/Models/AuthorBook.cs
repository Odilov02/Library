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
    [Table("author_book")]
    public class AuthorBook
    {
        [Key, DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        [Column("author_book_id")]
        [JsonPropertyName("author_book_id")]
        public int Id { get; set; }
        [JsonPropertyName("author_id")]
        [Column("author_id")]
        public int AuthorId { get; set; }
        public required Author Author { get; set; }
        [Column("book_id")]
        [JsonPropertyName("book_id")]
        public int BookId { get; set; }
        public required Book Book { get; set; }
    }
}