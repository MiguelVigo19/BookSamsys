using BookSamsys.Models;
using Microsoft.EntityFrameworkCore;
using BookSamsys.Data;









public class BookRepository : IBookRepository
{
    private readonly BookDbContext _context;

    public BookRepository(BookDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> ListarLivrosAsync(int page, int pageSize)
    {
        return await _context.Livros2
            .Include(l => l.Author) // Inclui os dados do Autor
            .Where(l => !l.IsDeleted)
            .OrderBy(l => l.BookName)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }










    public async Task<Book?> ObterPorISBNAsync(string isbn)
    {
        return await _context.Livros2.FirstOrDefaultAsync(l => l.ISBN == isbn && !l.IsDeleted);
    }




    public async Task AdicionarLivroAsync(Book livro)
    {
        _context.Livros2.Add(livro);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarLivroAsync(Book livro)
    {
        _context.Livros2.Update(livro);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirLivroAsync(string isbn)
    {
        var livro = await ObterPorISBNAsync(isbn);
        if (livro != null)
        {
            livro.IsDeleted = true;
            await _context.SaveChangesAsync();
        }
    }


    public async Task<Author?> ObterAutorPorIdAsync(int idAutor)
    {
        return await _context.Autores.FindAsync(idAutor);
    }
}