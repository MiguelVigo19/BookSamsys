using BookSamsys.DTO;
using BookSamsys.Models;



    public interface IBookService

    {
        Task<IEnumerable<Book>> ListarLivrosAsync(int page, int pageSize);
        Task<Book?> ObterPorISBNAsync(string isbn);
        Task AdicionarLivroAsync(AddLivrosDto livro);
        Task AtualizarLivroAsync(UpdateLivrosDto livro);
        Task ExcluirLivroAsync(string isbn);

       

}

