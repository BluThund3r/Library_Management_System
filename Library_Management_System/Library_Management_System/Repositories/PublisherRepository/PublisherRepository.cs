using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Library_Management_System.Repositories.PublisherRepository
{
    public class PublisherRepository: GenericRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(ApplicationContext context): base(context) { }

        public List<Publisher> GetAllIncludeBooks()
        {
            return table.Include(p => p.Books).ToList();
        }

        public Publisher GetPublisherByIdIncludeBooks(Guid Id)
        {
            return table.Include(p => p.Books).FirstOrDefault(p => p.Id.Equals(Id));
        }

        public Publisher GetPublisherByName(string name)
        {
            return table.FirstOrDefault(p => p.Name.Equals(name));
        }

        public Publisher GetPublisherByNameIncludeBooks(string name)
        {
            return table.Include(p => p.Books).FirstOrDefault(p => p.Name.Equals(name));
        }
    }
}
