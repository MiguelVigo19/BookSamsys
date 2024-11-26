using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookSamsys.Models
{
    public class Book
    {
        [Key] public string ISBN { get; set; } = null!;

        public string BookName { get; set; } = null!;


        [ForeignKey("Author")]
        [Required]

        public int IdAuthor { get; set; }

        [JsonIgnore]
        public  Author  Author { get; set; } = null!;

        public string AuthorName    { get; set; } = null!;

        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }

        [JsonIgnore]
        public bool IsDeleted { get; set; } = false; // Soft delete flag

    }
}
