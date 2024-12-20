using BookSamsys.DTO;
using BookSamsys.Models;





public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    


    public async Task<IEnumerable<BookDTO>> ListarLivrosAsync(int page, int pageSize)
    {

        var livros = await _repository.ListarLivrosAsync(page, pageSize);
        return livros.Select(l => new BookDTO
        {
            ISBN = l.ISBN,
            BookName = l.BookName,
            AuthorName = l.Author.Name,
            IdAuthor = l.IdAuthor,
            Price = l.Price,
        }
        );
        


    }


    




    public async Task<BookDTO?> ObterPorISBNAsync(string isbn)
    {
        
        var livro=await _repository.ObterPorISBNAsync(isbn);
        return new BookDTO
        {
            ISBN = livro.ISBN,
            BookName = livro.BookName,
            AuthorName = livro.Author.Name,
            IdAuthor=livro.IdAuthor,
            Price=livro.Price
        };
        

          

      




    }


    public async Task<Author?> ObterAutorPorIdAsync(int id)
    {
        return await _repository.ObterAutorPorIdAsync(id);
    }

    public async Task AdicionarLivroAsync(AddLivrosDto livro)
    {

      // Mapear o livro
        Book addLivro = new()
        {
            ISBN = livro.ISBN,
            BookName = livro.BookName,
            IdAuthor = livro.IdAuthor,
            Price = livro.Price
        };

        // Adicionar o livro
        await _repository.AdicionarLivroAsync(addLivro);
    }

    public async Task AtualizarLivroAsync(UpdateLivrosDto livro)
    {
        var existingbook = await _repository.ObterPorISBNAsync(livro.ISBN);
        if (existingbook == null)
        {
            throw new KeyNotFoundException($"Book with isbn {livro.ISBN} not found.");
        }
        


        existingbook.ISBN = livro.ISBN;
        existingbook.BookName = livro.BookName;
        existingbook.IdAuthor = livro.authorid;
        
        existingbook.Price = livro.Price;
await _repository.AtualizarLivroAsync(existingbook);
 }

    public async Task ExcluirLivroAsync(string isbn)
    {
        await _repository.ExcluirLivroAsync(isbn);
    }

}

        




    

