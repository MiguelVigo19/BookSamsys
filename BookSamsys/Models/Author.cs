using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace BookSamsys.Models
{
    public class Author
    {
        [Key] public int Id { get; set; } 

        [Required]
        [StringLength(100, ErrorMessage = "O nome do autor deve ter no máximo 100 caracteres.")]
        public  string Name { get; set; } = null!;
        [JsonIgnore]
        public ICollection<Book> Books { get; set; } = new List<Book>();
    
    }
}
