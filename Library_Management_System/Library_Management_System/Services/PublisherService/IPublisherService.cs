using Library_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Library_Management_System.Services.PublisherService
{
    public interface IPublisherService
    {
        public void Create(PublisherDTO publisherDto);
        public Task CreateAsync(PublisherDTO publisherDto);
        public void CreateRange(IEnumerable<PublisherDTO> publisherDTOs);
        public Task CreateRangeAsync(IEnumerable<PublisherDTO> publisherDTOs);
        public void Delete(PublisherDTO publisherDTO);
        public void DeleteRange(IEnumerable<PublisherDTO> publisherDTOs);
        public PublisherDTO GetById(Guid id);
        public Task<PublisherDTO> GetByIdAsync(Guid id);
        public Task<List<PublisherDTO>> GetAllAsync();
        public void Update(PublisherDTO publisherDTO);
        public void UpdateRange(IEnumerable<PublisherDTO> publisherDTOs);
        public List<PublisherDTO> GetAllIncludeBooks();
        public PublisherDTO GetPublisherByIdIncludeBooks(Guid id);
        public PublisherDTO GetPublisherByName(string name);
        public PublisherDTO GetPublisherByNameIncludeBooks(string name);
    }
}
