using Microsoft.EntityFrameworkCore;
using BookSamsys.Models;
using System.Drawing.Text;
using Microsoft.Identity.Client;
using BookSamsys.DTO;

namespace BookSamsys.Data
{
    public class BookDbContext : DbContext
    {
       

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Livros2 { get; set; }
        public DbSet<Author> Autores { get; set; }

       


    }


}
