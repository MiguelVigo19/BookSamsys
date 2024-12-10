namespace BookSamsys.DTO
{
    public class BookDTO
    {
        public string? ISBN { get; set; }
        public string? BookName { get; set; }

        public string? AuthorName { get; set; }

        public int IdAuthor { get; set; }
        public string? Price { get; set; }

    }
}
