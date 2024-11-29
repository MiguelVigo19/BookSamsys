namespace BookSamsys.DTO
{
    public class AddLivrosDto
    {
        public string? ISBN { get; set; } 
        public string? BookName { get; set; } 
        public string? AuthorName { get; set; } 
        public int authorid { get; set; }

        public decimal Price { get; set; }
    }

}
