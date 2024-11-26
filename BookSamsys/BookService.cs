using BookSamsys.Models;





public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Book>> ListarLivrosAsync(int page, int pageSize)
    {

        var livros = await _repository.ListarLivrosAsync(page, pageSize);
        return livros.Select(l => new Book
        {
            ISBN = l.ISBN,
            BookName = l.BookName,
            IdAuthor=l.Author.Id,
            Price = l.Price,
            AuthorName = l.Author.Name // Adiciona o nome do autor no DTO
        });


     }

    public async Task<Book?> ObterPorISBNAsync(string isbn)
    {
        return await _repository.ObterPorISBNAsync(isbn);
    }

    public async Task AdicionarLivroAsync(Book livro)
    {
        if (livro.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        if (await _repository.ObterPorISBNAsync(livro.ISBN) != null)
            throw new ArgumentException("ISBN já cadastrado.");

        await _repository.AdicionarLivroAsync(livro);
    }

    public async Task AtualizarLivroAsync(Book livro)
    {
        if (livro.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        await _repository.AtualizarLivroAsync(livro);
    }

    public async Task ExcluirLivroAsync(string isbn)
    {
        await _repository.ExcluirLivroAsync(isbn);
    }

}
        




    

