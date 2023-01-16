using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.AuthorRepository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationContext _context) : base(_context) { }
        public async Task<List<Author>> GetAuthorsByFirstNameAsync(string firstName)
        {
            return  await table.Where(x => x.FirstName.ToLower().Trim().Equals(firstName.ToLower().Trim())).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsByLastNameAsync(string lastName)
        {
            return await table.Where(x => x.LastName.ToLower().Trim().Equals(lastName.ToLower().Trim())).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsWithAgeExactAsync(int age)
        {
            return await table.Where(x => x.Age.Equals(age)).ToListAsync();
        }

        public async Task<List<Author>> GetAuthorsWithAgeGreaterThanAsync(int age)
        {
            return await table.Where(x => x.Age > age).ToListAsync();   
        }

        public async Task<List<Author>> GetAuthorsWithAgeLowerThanAsync(int age)
        {
            return await table.Where(x => x.Age < age).ToListAsync();
        }
    }
}
