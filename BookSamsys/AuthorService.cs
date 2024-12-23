using BookSamsys.DTO;
using BookSamsys.Models;



    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        public AuthorService(IAuthorRepository repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Author>> GetAllAsync() => await _repository.GetAllAsync();
        public async Task<Author> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);




    public async Task AddAsync(AddAutordto autor)
    {
        Author newautor = new()
        { 
            Name = autor.Name
        };
        if (string.IsNullOrWhiteSpace(autor.Name))
            throw new ArgumentException("Name is required.");


        await _repository.AddAsync(newautor);
    }





    public async Task UpdateAsync(AtualizarAutorDTO autor)
    {
        var existingAuthor = await _repository.GetByIdAsync(autor.id);
        if (existingAuthor == null)
        {
            throw new KeyNotFoundException($"Author with ID {autor.id} not found.");
        }

        // Atualiza as propriedades da entidade existente
        existingAuthor.Name = autor.Name;

        // Passa a entidade atualizada para o repositório
        await _repository.UpdateAsync(existingAuthor);
    }
      
    
    public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    


  }


