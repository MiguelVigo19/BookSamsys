﻿namespace BookSamsys.DTO
{
    public class AddLivrosDto
    {
        public string? ISBN { get; set; }
        public string? BookName { get; set; }
        
        public int IdAuthor { get; set; }

        public string? Price { get; set; }

    }
}
