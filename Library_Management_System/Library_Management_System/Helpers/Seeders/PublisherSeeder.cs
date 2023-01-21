using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Helpers.Seeders
{
    public class PublisherSeeder
    {
        public readonly ApplicationContext context;

        public PublisherSeeder(ApplicationContext _context)
        {
            context = _context;
        }

        public void SeedInitialPublishers()
        {
            if(!context.Publishers.Any())
            {
                var publisher1 = new Publisher
                {
                    Name = "Paladin",
                    Address = "UK, London, Short Street 123"
                };

                var publisher2 = new Publisher
                {
                    Name = "YoungArt",
                    Address = "Netherlands, Dokter Duyvendakhof 142"
                };

                var publisher3 = new Publisher
                {
                    Name = "Armada",
                    Address = "Bucharest, Independence Avenue 201"
                };

                context.Publishers.Add(publisher1);
                context.Publishers.Add(publisher2);
                context.Publishers.Add(publisher3);
                context.SaveChanges();
            }
        }
    }
}
