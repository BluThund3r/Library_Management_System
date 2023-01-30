using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.AuthorsWriteBooksRepository;
using System.Linq.Expressions;

namespace Library_Management_System.Services.AuthorsWriteBooksService
{
    public class AuthorsWriteBooksService : IAuthorsWriteBooksService
    {
        public readonly IAuthorsWriteBooksRepository repo;
        public readonly IMapper mapper;

        public AuthorsWriteBooksService(IAuthorsWriteBooksRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(AuthorsWriteBooksDTO awbDto)
        {
            repo.Create(mapper.Map<AuthorsWriteBooks>(awbDto));
            repo.Save();
        }

        public async Task CreateAsync(AuthorsWriteBooksDTO awbDto)
        {
            await repo.CreateAsync(mapper.Map<AuthorsWriteBooks>(awbDto));
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos)
        {
            var awbs = new List<AuthorsWriteBooks>();
            foreach(var elem in awbDtos)
            {
                awbs.Add(mapper.Map<AuthorsWriteBooks>(elem));
            }

            repo.CreateRange(awbs);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<AuthorsWriteBooksDTO> awbDtos)
        {
            var awbs = new List<AuthorsWriteBooks>();
            foreach (var elem in awbDtos)
            {
                awbs.Add(mapper.Map<AuthorsWriteBooks>(elem));
            }

            await repo.CreateRangeAsync(awbs);
            await repo.SaveAsync();
        }

        public void Delete(AuthorsWriteBooksDTO awbDto)
        {
            repo.Delete(mapper.Map<AuthorsWriteBooks>(awbDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos)
        {
            var awbs = new List<AuthorsWriteBooks>();
            foreach (var elem in awbDtos)
            {
                awbs.Add(mapper.Map<AuthorsWriteBooks>(elem));
            }

            repo.DeleteRange(awbs);
            repo.Save();
        }

        public List<AuthorsWriteBooksDTO> GetAll()
        {
            var awbs = repo.GetAll();
            var awbDtos = new List<AuthorsWriteBooksDTO>();
            foreach(var elem in awbs)
            {
                awbDtos.Add(mapper.Map<AuthorsWriteBooksDTO>(elem));
            }

            return awbDtos;
        }

        public async Task<List<AuthorsWriteBooksDTO>> GetAllAsync()
        {
            var awbs = await repo.GetAllAsync();
            var awbDtos = new List<AuthorsWriteBooksDTO>();
            foreach (var elem in awbs)
            {
                awbDtos.Add(mapper.Map<AuthorsWriteBooksDTO>(elem));
            }

            return awbDtos;
        }

        public List<AuthorsWriteBooksDTO> GetAllByAuthorId(Guid authorId)
        {
            var awbs = repo.GetAllByAuthorId(authorId);
            var awbDtos = new List<AuthorsWriteBooksDTO>();
            foreach (var elem in awbs)
            {
                awbDtos.Add(mapper.Map<AuthorsWriteBooksDTO>(elem));
            }

            return awbDtos;
        }

        public List<AuthorsWriteBooksDTO> GetAllByBookId(Guid bookId)
        {
            var awbs = repo.GetAllByBookId(bookId);
            var awbDtos = new List<AuthorsWriteBooksDTO>();
            foreach (var elem in awbs)
            {
                awbDtos.Add(mapper.Map<AuthorsWriteBooksDTO>(elem));
            }

            return awbDtos;
        }

        public void Update(AuthorsWriteBooksDTO awbDto)
        {
            repo.Update(mapper.Map<AuthorsWriteBooks>(awbDto));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<AuthorsWriteBooksDTO> awbDtos)
        {
            var awbs = new List<AuthorsWriteBooks>();
            foreach(var elem in awbs)
            {
                awbs.Add(mapper.Map<AuthorsWriteBooks>(elem));
            }

            repo.UpdateRange(awbs);
            repo.Save();
        }
    }
}
