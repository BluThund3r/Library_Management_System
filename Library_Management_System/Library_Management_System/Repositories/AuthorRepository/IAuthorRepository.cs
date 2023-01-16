using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.AuthorRepository
{
    public interface IAuthorRepository : IGenericRepository<Author>
    {
        Task<List<Author>> GetAuthorsByFirstNameAsync(string firstName);
        Task<List<Author>> GetAuthorsByLastNameAsync(string lastName);
        Task<List<Author>> GetAuthorsWithAgeGreaterThanAsync(int age);
        Task<List<Author>> GetAuthorsWithAgeLowerThanAsync(int age);
        Task<List<Author>> GetAuthorsWithAgeExactAsync(int age);

    }
}
