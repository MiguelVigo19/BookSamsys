using BookSamsys.DTO;
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

    public async Task AdicionarLivroAsync(AddLivrosDto livro)
    {

        Book addlivro = new()
        {
            ISBN = livro.ISBN,
            BookName = livro.BookName,
            IdAuthor = livro.authorid,
            AuthorName = livro.AuthorName,
            Price = livro.Price
        };
        if (livro.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        if (await _repository.ObterPorISBNAsync(livro.ISBN) != null)
            throw new ArgumentException("ISBN já cadastrado.");

        await _repository.AdicionarLivroAsync(addlivro);
    }

    public async Task AtualizarLivroAsync(UpdateLivrosDto livro)
    {
        Book uplivro = new()
        {
            ISBN = livro.ISBN,
            BookName = livro.BookName,
            IdAuthor = livro.authorid,
            AuthorName = livro.AuthorName,
            Price = livro.Price
        };

        if (livro.Price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");

        await _repository.AtualizarLivroAsync(uplivro);
    }

    public async Task ExcluirLivroAsync(string isbn)
    {
        await _repository.ExcluirLivroAsync(isbn);
    }

}
        




    

