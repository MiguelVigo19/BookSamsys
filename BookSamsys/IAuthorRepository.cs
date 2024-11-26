using BookSamsys.Models;



    public interface IAuthorRepository
    {

        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int id);
        Task AddAsync(Author autor);
        Task UpdateAsync(Author autor);
        Task DeleteAsync(int id);


    }

