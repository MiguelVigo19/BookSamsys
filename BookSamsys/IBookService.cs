using BookSamsys.DTO;
using BookSamsys.Models;



    public interface IBookService

    {
        Task<IEnumerable<BookDTO>> ListarLivrosAsync(int page, int pageSize);
        Task<BookDTO?> ObterPorISBNAsync(string isbn);
        Task AdicionarLivroAsync(AddLivrosDto livro);
        Task AtualizarLivroAsync(UpdateLivrosDto livro);
        Task ExcluirLivroAsync(string isbn);
        Task <Author?>ObterAutorPorIdAsync(int id);


}

