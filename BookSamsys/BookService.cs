using BookSamsys.DTO;
using BookSamsys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly MessagingHelper _messagingHelper;

    public BookService(IBookRepository repository, MessagingHelper messagingHelper)
    {
        _repository = repository;
        _messagingHelper = messagingHelper;
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
        });
    }

    public async Task<BookDTO?> ObterPorISBNAsync(string isbn)
    {
        var livro = await _repository.ObterPorISBNAsync(isbn);

        if (livro == null)
            throw new KeyNotFoundException("Livro não encontrado.");

        return new BookDTO
        {
            ISBN = livro.ISBN,
            BookName = livro.BookName,
            AuthorName = livro.Author.Name,
            IdAuthor = livro.IdAuthor,
            Price = livro.Price
        };
    }

    public async Task<Author?> ObterAutorPorIdAsync(int id)
    {
        return await _repository.ObterAutorPorIdAsync(id);
    }
    /**********************************add********************************/


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

        // Validação do ISBN
        if (string.IsNullOrEmpty(livro.ISBN))
            throw new ArgumentException("O ISBN é obrigatório.");

        // Validação do nome do livro
        if (string.IsNullOrEmpty(livro.BookName))
            throw new ArgumentException("O título do livro é obrigatório.");

        // Verificação se o livro já existe
        var livroExistente = await _repository.ObterPorISBNAsync(livro.ISBN);
        if (livroExistente != null)
            throw new InvalidOperationException("O livro já existe no sistema.");

        // Adicionar o livro
        await _repository.AdicionarLivroAsync(addLivro);

        // Enviar notificação
        string message = $"Livro adicionado: ISBN={livro.ISBN}, Nome={livro.BookName}";
        _messagingHelper.SendMessage("BookNotifications", message);
    }


    /*************************************update**********************************/


    public async Task AtualizarLivroAsync(UpdateLivrosDto livro)
    {
        var existingBook = await _repository.ObterPorISBNAsync(livro.ISBN);
        if (existingBook == null)
            throw new KeyNotFoundException($"Livro com ISBN {livro.ISBN} não encontrado.");

        existingBook.BookName = livro.BookName;
        existingBook.IdAuthor = livro.authorid;
        existingBook.Price = livro.Price;

        await _repository.AtualizarLivroAsync(existingBook);

        // Enviar notificação
        string message = $"Livro atualizado: ISBN={livro.ISBN}, Nome={livro.BookName}";
        _messagingHelper.SendMessage("BookNotifications", message);
    }
    /***********************************delete**************************************/


    public async Task ExcluirLivroAsync(string isbn)
    {
        var livroExistente = await _repository.ObterPorISBNAsync(isbn);
        if (livroExistente == null)
            throw new KeyNotFoundException($"O livro com o ISBN {isbn} não existe.");

        await _repository.ExcluirLivroAsync(isbn);

        // Enviar notificação
        string message = $"Livro excluído: ISBN={isbn}";
        _messagingHelper.SendMessage("BookNotifications", message);
    }
}
