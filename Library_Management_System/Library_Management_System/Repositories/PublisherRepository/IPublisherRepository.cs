using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.PublisherRepository
{
    public interface IPublisherRepository: IGenericRepository<Publisher>
    {
        public Publisher GetPublisherByName(string name);
        public Publisher GetPublisherByNameIncludeBooks(string name);
        public Publisher GetPublisherByIdIncludeBooks(Guid Id);
        public List<Publisher> GetAllIncludeBooks();
    }
}
