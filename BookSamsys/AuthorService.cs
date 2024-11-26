﻿using BookSamsys.DTO;
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
        await _repository.AddAsync(newautor);
    }
        public async Task UpdateAsync(Author autor) => await _repository.UpdateAsync(autor);
        public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
    }


