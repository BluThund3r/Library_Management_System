using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.AuthorsWriteBooksRepository
{
    public class AuthorsWriteBooksRepository : IAuthorsWriteBooksRepository
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<AuthorsWriteBooks> table;

        public AuthorsWriteBooksRepository(ApplicationContext context_)
        {
            context = context_;
            table = context.Set<AuthorsWriteBooks>();
        }

        public void Create(AuthorsWriteBooks awb)
        {
            table.Add(awb);
        }

        public async Task CreateAsync(AuthorsWriteBooks awb)
        {
            await table.AddAsync(awb);
        }

        public void CreateRange(IEnumerable<AuthorsWriteBooks> awbs)
        {
            table.AddRange(awbs);
        }

        public async Task CreateRangeAsync(IEnumerable<AuthorsWriteBooks> awbs)
        {
            await table.AddRangeAsync(awbs);
        }

        public void Delete(AuthorsWriteBooks awb)
        {
            table.Remove(awb);
        }

        public void DeleteRange(IEnumerable<AuthorsWriteBooks> awbs)
        {
            table.RemoveRange(awbs);
        }

        public List<AuthorsWriteBooks> GetAll()
        {
            return table.ToList();
        }

        public async Task<List<AuthorsWriteBooks>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public List<AuthorsWriteBooks> GetAllByAuthorId(Guid authorId)
        {
            return table.Where(x => x.AuthorId.Equals(authorId)).ToList();
        }

        public List<AuthorsWriteBooks> GetAllByBookId(Guid bookId)
        {
            return table.Where(x => x.BookId.Equals(bookId)).ToList();
        }

        public bool Save()
        {
            return context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(AuthorsWriteBooks awb)
        {
            table.Update(awb);
        }

        public void UpdateRange(IEnumerable<AuthorsWriteBooks> awbs)
        {
            table.UpdateRange(awbs);
        }
    }
}
