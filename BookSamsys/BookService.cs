using BookSamsys.DTO;
using BookSamsys.Models;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    

    public BookService(IBookRepository repository )
    {
        _repository = repository;
        
    }

    public async Task<IEnumerable<BookDTO>> ListarLivrosAsync(int page, int pageSize)
    {
        var livros = await _repository.ListarLivrosAsync(page, pageSize);
        var messageDto = new MessageDTO { Message = "Listar Livros !" };
        var messagingHelper = new MessagingHelperDTO();
        messagingHelper.ValidateMessage(messageDto);
        messagingHelper.SendMessage(messageDto);

        if (messageDto.Success == true)
        {
            Console.WriteLine("A mensagem foi envidada com sucesso total.");
        }
        else 
        {
            Console.WriteLine("Falha ao enviar a mensagem.");
        }
        


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






    /**********************************ADD********************************/


    public async Task AdicionarLivroAsync(AddLivrosDto livro)
    {
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

        // Enviar notificação
        // Instância do helper
        var messageDto = new MessageDTO { Message = "Vais Adicionar um Livro!" };
        var messagingHelper = new MessagingHelperDTO();
        messagingHelper.ValidateMessage(messageDto);
        messagingHelper.SendMessage(messageDto);

        if (messageDto.Success== true)
        {
            Console.WriteLine("A mensagem foi enviada com sucesso total.");
        }
        if (messageDto.Success == false)
        {
            Console.WriteLine("Falha ao enviar a mensagem.");
        }
        



      
        
    }




    /*************************************UPDATE**********************************/


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
        
    }




    /***********************************DELETE**************************************/


    public async Task ExcluirLivroAsync(string isbn)
    {
        var livroExistente = await _repository.ObterPorISBNAsync(isbn);
        if (livroExistente == null)
            throw new KeyNotFoundException($"O livro com o ISBN {isbn} não existe.");

        await _repository.ExcluirLivroAsync(isbn);

        // Enviar notificação
        
        var messageDto = new MessageDTO { Message = "apagar Livros !" };
        var messagingHelper = new MessagingHelperDTO();
        messagingHelper.ValidateMessage(messageDto);
        messagingHelper.SendMessage(messageDto);

        if (messageDto.Success == true)
        {
            Console.WriteLine("A mensagem foi envidada com sucesso total.");
        }
        else
        {
            Console.WriteLine("Falha ao enviar a mensagem.");
        }

    }
}
