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
            IdAuthor = l.Author.Id,
            Price = l.Price,
            AuthorName = l.Author.Name
            // Adiciona o nome do autor no DTO
        });


    }

    public async Task<Book?> ObterPorISBNAsync(string isbn)
    {
        return await _repository.ObterPorISBNAsync(isbn);
    }


    public async Task<Author?> ObterAutorPorIdAsync(int id)
    {
        return await _repository.ObterAutorPorIdAsync(id);
    }

    public async Task AdicionarLivroAsync(AddLivrosDto livro)
    {

        var autorExistente = await _repository.ObterAutorPorIdAsync(livro.IdAuthor);
        if (autorExistente == null)
        {
            throw new Exception("O autor especificado não existe.");
        }

        var livroExistente = await _repository.ObterPorISBNAsync(livro.ISBN);
        if (autorExistente == null)
        {
            throw new Exception("O lIVRO especificado não existe.");
        }// Verificar se o ISBN já existe

        // Mapear o livro
        Book addLivro = new()
        {
            ISBN = livro.ISBN!,
            BookName = livro.BookName!,
            IdAuthor = livro.IdAuthor!,
            Author = autorExistente, // Associa o autor existente
            Price = livro.Price!
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

        




    

