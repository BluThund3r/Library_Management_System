using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.AuthorRepository;
using System.Linq.Expressions;

namespace Library_Management_System.Services.AuthorService
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository repo;
        public readonly IMapper mapper;

        public AuthorService(IAuthorRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(AuthorDTO authorDto)
        {
            var author = mapper.Map<Author>(authorDto);
            repo.Create(author);
            repo.Save();
        }

        public async Task CreateAsync(AuthorDTO authorDto)
        {
            var author = mapper.Map<Author>(authorDto);
            await repo.CreateAsync(author);
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<AuthorDTO> authorDtos)
        {
            var authors = new List<Author>();
            foreach(var elem in authorDtos)
            {
                authors.Add(mapper.Map<Author>(elem));
            }

            repo.CreateRange(authors);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<AuthorDTO> authorDtos)
        {
            var authors = new List<Author>();
            foreach (var elem in authorDtos)
            {
                authors.Add(mapper.Map<Author>(elem));
            }

           await repo.CreateRangeAsync(authors);
            await repo.SaveAsync();
        }

        public void Delete(AuthorDTO authorDto)
        {
            repo.Delete(mapper.Map<Author>(authorDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<AuthorDTO> authorDtos)
        {
            var authors = new List<Author>();
            foreach (var elem in authorDtos)
            {
                authors.Add(mapper.Map<Author>(elem));
            }

            repo.DeleteRange(authors);
            repo.Save();
        }

        public async Task<List<AuthorDTO>> GetAllAsync()
        {
            var authors = await repo.GetAllAsync();
            var authorDtos = new List<AuthorDTO>();
            foreach(var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public async Task<List<AuthorDTO>> GetAuthorsByFirstNameAsync(string firstName)
        {
            var authors = await repo.GetAuthorsByFirstNameAsync(firstName);
            var authorDtos = new List<AuthorDTO>();
            foreach (var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public async Task<List<AuthorDTO>> GetAuthorsByLastNameAsync(string lastName)
        {
            var authors = await repo.GetAuthorsByLastNameAsync(lastName);
            var authorDtos = new List<AuthorDTO>();
            foreach (var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public async Task<List<AuthorDTO>> GetAuthorsWithAgeExactAsync(int age)
        {
            var authors = await repo.GetAuthorsWithAgeExactAsync(age);
            var authorDtos = new List<AuthorDTO>();
            foreach (var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public async Task<List<AuthorDTO>> GetAuthorsWithAgeGreaterThanAsync(int age)
        {
            var authors = await repo.GetAuthorsWithAgeGreaterThanAsync(age);
            var authorDtos = new List<AuthorDTO>();
            foreach (var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public async Task<List<AuthorDTO>> GetAuthorsWithAgeLowerThanAsync(int age)
        {
            var authors = await repo.GetAuthorsWithAgeLowerThanAsync(age);
            var authorDtos = new List<AuthorDTO>();
            foreach (var elem in authors)
            {
                authorDtos.Add(mapper.Map<AuthorDTO>(elem));
            }

            return authorDtos;
        }

        public AuthorDTO GetById(Guid id)
        {
            var temp = repo.FindById(id);
            if (temp == null)
                return null;
            return mapper.Map<AuthorDTO>(temp);
        }

        public async Task<AuthorDTO> GetByIdAsync(Guid id)
        {
            var temp = await repo.FindByIdAsync(id);
            if (temp == null)
                return null;
            return mapper.Map<AuthorDTO>(temp);
        }

        public void Update(AuthorDTO authorDTO)
        {
            repo.Update(mapper.Map<Author>(authorDTO));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<AuthorDTO> authorDtos)
        {
            var authors = new List<Author>();
            foreach(var elem in authorDtos)
            {
                authors.Add(mapper.Map<Author>(elem));
            }

            repo.UpdateRange(authors);
            repo.Save();
        }
    }
}
