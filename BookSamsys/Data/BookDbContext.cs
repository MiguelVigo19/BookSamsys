using Microsoft.EntityFrameworkCore;
using BookSamsys.Models;
using System.Drawing.Text;
using Microsoft.Identity.Client;

namespace BookSamsys.Data
{
    public class BookDbContext : DbContext
    {
       

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }

        public DbSet<Book> Livros2 { get; set; }
        public DbSet<Author> Autores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure one-to-many relationship
            modelBuilder.Entity<Book>()
                .HasOne(l => l.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(l => l.IdAuthor)
                .OnDelete(DeleteBehavior.Cascade); // Cascade delete
        }


    }


}
