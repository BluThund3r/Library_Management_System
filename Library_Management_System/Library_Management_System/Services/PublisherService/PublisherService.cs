using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.PublisherRepository;

namespace Library_Management_System.Services.PublisherService
{
    public class PublisherService: IPublisherService
    {
        public readonly IPublisherRepository repo;
        public readonly IMapper mapper;

        public PublisherService(IPublisherRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(PublisherDTO publisherDto)
        {
            repo.Create(mapper.Map<Publisher>(publisherDto));
            repo.Save();
        }

        public async Task CreateAsync(PublisherDTO publisherDto)
        {
            await repo.CreateAsync(mapper.Map<Publisher>(publisherDto));
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<PublisherDTO> publisherDTOs)
        {
            var publishers = new List<Publisher>();
            foreach(var elem in publisherDTOs)
            {
                publishers.Add(mapper.Map<Publisher>(elem));
            }

            repo.CreateRange(publishers);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<PublisherDTO> publisherDTOs)
        {
            var publishers = new List<Publisher>();
            foreach (var elem in publisherDTOs)
            {
                publishers.Add(mapper.Map<Publisher>(elem));
            }

            await repo.CreateRangeAsync(publishers);
            await repo.SaveAsync();
        }

        public void Delete(PublisherDTO publisherDTO)
        {
            repo.Delete(mapper.Map<Publisher>(publisherDTO));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<PublisherDTO> publisherDTOs)
        {
            var publishers = new List<Publisher>();
            foreach(var elem in publisherDTOs)
            {
                publishers.Add(mapper.Map<Publisher>(elem));
            }

            repo.DeleteRange(publishers);
            repo.Save();    
        }

        public async Task<List<PublisherDTO>> GetAllAsync()
        {
            var publishers = await repo.GetAllAsync();
            var publisherDtos = new List<PublisherDTO>();
            foreach(var elem in publishers)
            {
                publisherDtos.Add(mapper.Map<PublisherDTO>(elem));
            }

            return publisherDtos;
        }

        public List<PublisherDTO> GetAllIncludeBooks()
        {
            var publishers = repo.GetAllIncludeBooks();
            var publisherDtos = new List<PublisherDTO>();
            foreach(var elem in publishers)
            {
                publisherDtos.Add(mapper.Map<PublisherDTO>(elem));
            }

            return publisherDtos;
        }

        public PublisherDTO GetById(Guid id)
        {
            var temp = repo.FindById(id);
            if (temp == null)
                return null;
            return mapper.Map<PublisherDTO>(temp);
        }

        public async Task<PublisherDTO> GetByIdAsync(Guid id)
        {
            var temp = await repo.FindByIdAsync(id);
            if (temp == null)
                return null;
            return mapper.Map<PublisherDTO>(temp);
        }

        public PublisherDTO GetPublisherByIdIncludeBooks(Guid id)
        {
            var temp = repo.GetPublisherByIdIncludeBooks(id);
            if (temp == null)
                return null;
            return mapper.Map<PublisherDTO>(temp);
        }

        public PublisherDTO GetPublisherByName(string name)
        {
            var temp = repo.GetPublisherByName(name);
            if (temp == null)
                return null;
            return mapper.Map<PublisherDTO>(temp);
        }

        public PublisherDTO GetPublisherByNameIncludeBooks(string name)
        {
            var temp = repo.GetPublisherByNameIncludeBooks(name);
            if (temp == null)
                return null;
            return mapper.Map<PublisherDTO>(temp);
        }

        public void Update(PublisherDTO publisherDTO)
        {
            repo.Update(mapper.Map<Publisher>(publisherDTO));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<PublisherDTO> publisherDTOs)
        {
            var publishers = new List<Publisher>();
            foreach(var elem in publisherDTOs)
            {
                publishers.Add(mapper.Map<Publisher>(elem));
            }

            repo.UpdateRange(publishers);
            repo.Save();
        }
    }
}
