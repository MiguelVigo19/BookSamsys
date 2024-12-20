using BookSamsys.DTO;
using BookSamsys.Models;
using System.Drawing;



public interface IBookRepository
    {
        Task<IEnumerable<Book>> ListarLivrosAsync(int page, int pageSize);
        Task<Book?> ObterPorISBNAsync(string isbn);
    
    Task AdicionarLivroAsync(Book livro);
        Task AtualizarLivroAsync(Book livro);
        Task ExcluirLivroAsync(string isbn);
    Task <Author?>ObterAutorPorIdAsync(int id);

}

