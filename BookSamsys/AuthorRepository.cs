using BookSamsys.Data;
using BookSamsys.Models;
using Microsoft.EntityFrameworkCore;


    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookDbContext _context;

        public AuthorRepository(BookDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Autores.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
            var author = await _context.Autores.FindAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with ID {id} was not found.");
            }
            return author;
        }

        public async Task AddAsync(Author autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Author autor)
        {
            _context.Autores.Update(autor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor != null)
            {
                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();
            }
        }

    }
