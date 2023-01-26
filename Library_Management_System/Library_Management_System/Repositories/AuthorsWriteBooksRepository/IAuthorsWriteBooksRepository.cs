using Library_Management_System.Models;

namespace Library_Management_System.Repositories.AuthorsWriteBooksRepository
{
    public interface IAuthorsWriteBooksRepository
    {
        // Create
        void Create(AuthorsWriteBooks awb);
        Task CreateAsync(AuthorsWriteBooks awb);
        void CreateRange(IEnumerable<AuthorsWriteBooks> awbs);
        Task CreateRangeAsync(IEnumerable<AuthorsWriteBooks> awbs);

        // Find
        public List<AuthorsWriteBooks> GetAll();

        public Task<List<AuthorsWriteBooks>> GetAllAsync();

        public List<AuthorsWriteBooks> GetAllByAuthorId(Guid authorId);

        public List<AuthorsWriteBooks> GetAllByBookId(Guid bookId);


        // Update
        void Update(AuthorsWriteBooks awb);
        void UpdateRange(IEnumerable<AuthorsWriteBooks> awbs);

        // Delete
        void Delete(AuthorsWriteBooks awb);
        void DeleteRange(IEnumerable<AuthorsWriteBooks> awbs);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}
