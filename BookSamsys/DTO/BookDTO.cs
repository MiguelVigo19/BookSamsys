using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;



namespace BookSamsys.DTO
{
    public class BookDTO
    {
        [Key]public string? ISBN { get; set; }
        public string? BookName { get; set; }

        public string? AuthorName { get; set; }

        public int IdAuthor { get; set; }
        public string? Price { get; set; }
        [JsonIgnore]
        public bool IsDeleted { get; set; } = false; // Soft delete flag


    }

}

