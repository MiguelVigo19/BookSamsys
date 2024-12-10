namespace BookSamsys.DTO
{
    public class UpdateLivrosDto
    {
        public string? ISBN { get; set; } 
        public string? BookName { get; set; } 
       
        public int authorid { get; set; } 

        public string? Price { get; set; } 
    }
}

