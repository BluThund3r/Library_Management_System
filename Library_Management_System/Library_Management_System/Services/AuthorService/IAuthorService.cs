using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.Identity.Client;

namespace Library_Management_System.Services.AuthorService
{
    public interface IAuthorService
    {
        public void Create(AuthorDTO authorDto);
        public Task CreateAsync(AuthorDTO authorDto);
        public void CreateRange(IEnumerable<AuthorDTO> authorDtos);
        public Task CreateRangeAsync(IEnumerable<AuthorDTO> authorDtos);
        public void Delete(AuthorDTO authorDto);
        public void DeleteRange(IEnumerable<AuthorDTO> authorDtos);
        public AuthorDTO GetById(Guid id);
        public Task<AuthorDTO> GetByIdAsync(Guid id);
        public Task<List<AuthorDTO>> GetAllAsync();
        public void Update(AuthorDTO authorDTO);
        public void UpdateRange(IEnumerable<AuthorDTO> authorDtos);
        public Task<List<AuthorDTO>> GetAuthorsByFirstNameAsync(string firstName);
        public Task<List<AuthorDTO>> GetAuthorsByLastNameAsync(string lastName);
        public Task<List<AuthorDTO>> GetAuthorsWithAgeExactAsync(int age);
        public Task<List<AuthorDTO>> GetAuthorsWithAgeGreaterThanAsync(int age);
        public Task<List<AuthorDTO>> GetAuthorsWithAgeLowerThanAsync(int age);
    }
}
