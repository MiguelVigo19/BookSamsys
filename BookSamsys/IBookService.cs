using BookSamsys.Models;



    public interface IBookService

    {
        Task<IEnumerable<Book>> ListarLivrosAsync(int page, int pageSize);
        Task<Book?> ObterPorISBNAsync(string isbn);
        Task AdicionarLivroAsync(Book livro);
        Task AtualizarLivroAsync(Book livro);
        Task ExcluirLivroAsync(string isbn);

       

}

