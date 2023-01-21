using Library_Management_System.Data;
using Library_Management_System.Models;
using System.Net.Cache;

namespace Library_Management_System.Helpers.Seeders
{
    public class AuthorSeeder
    {
        public readonly ApplicationContext context;

        public AuthorSeeder(ApplicationContext _context)
        {
            context = _context;
        }

        public void SeedInitialAuthors()
        {
            if(!context.Authors.Any())
            {
                var author1 = new Author
                {
                    FirstName = "Pierce",
                    LastName = "Brown",
                    Age = 30
                };

                var author2 = new Author
                {
                    FirstName = "Sabaa",
                    LastName = "Tahir",
                    Age = 32
                };

                var author3 = new Author
                {
                    FirstName = "Suzanne",
                    LastName = "Collins",
                    Age = 40
                };

                context.Authors.Add(author1);
                context.Authors.Add(author2);
                context.Authors.Add(author3);
                context.SaveChanges();
            }
        }
    }
}
