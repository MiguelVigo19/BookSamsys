using BookSamsys.DTO;
using BookSamsys.Models;



    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<Author> GetByIdAsync(int  id);
        Task AddAsync(AddAutordto autor);
        Task UpdateAsync(AtualizarAutorDTO autor);
        Task DeleteAsync(int id);
    }


