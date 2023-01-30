using Library_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Library_Management_System.Services.AuthorsWriteBooksService
{
    public interface IAuthorsWriteBooksService
    {
        public void Create(AuthorsWriteBooksDTO awbDto);
        public void CreateRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos);
        public Task CreateAsync(AuthorsWriteBooksDTO awbDto);
        public Task CreateRangeAsync(IEnumerable<AuthorsWriteBooksDTO> awbDtos);
        public void Delete(AuthorsWriteBooksDTO awbDto);
        public void DeleteRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos);
        public List<AuthorsWriteBooksDTO> GetAll();
        public Task<List<AuthorsWriteBooksDTO>> GetAllAsync();
        public List<AuthorsWriteBooksDTO> GetAllByAuthorId(Guid authorId);
        public List<AuthorsWriteBooksDTO> GetAllByBookId(Guid bookId);
        public void Update(AuthorsWriteBooksDTO awbDto);
        public void UpdateRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos);
    }
}
