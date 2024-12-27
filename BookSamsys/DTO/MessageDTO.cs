using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BookSamsys.DTO
{
    public class MessageDTO
    {

        public string? Message { get; set; } = "";
        public bool Success { get; set; }
        
    }

    public class MessageDTO<T>
    {
        public string? Message { get; set; } = "";
        public bool Success { get; set; }
         public T Objt { get; set; } 
        
    }
}
