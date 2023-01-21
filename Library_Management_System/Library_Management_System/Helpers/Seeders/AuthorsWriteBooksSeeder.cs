using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Helpers.Seeders
{
    public class AuthorsWriteBooksSeeder
    {
        public readonly ApplicationContext context;

        public AuthorsWriteBooksSeeder(ApplicationContext _context)
        {
            context = _context;
        }

        public void SeedInitialAuthorsWriteBooks()
        {
            if(!context.AuthorsWriteBooks.Any())
            {
                var awb1 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Pierce")).Id,
                    BookId = context.Books.First(b => b.Title.ToLower().Equals("red rising")).Id
                };

                var awb2 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Pierce")).Id,
                    BookId = context.Books.First(b => b.Title.ToLower().Equals("golden son")).Id
                };

                var awb3 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Sabaa")).Id,
                    BookId = context.Books.First(b => b.Title.Equals("Elias Si Spioana Carturarilor: O torta in noapte")).Id
                };

                var awb4 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Sabaa")).Id,
                    BookId = context.Books.First(b => b.Title.Equals("Elias Si Spioana Carturarilor: Focul din cenusa")).Id
                };

                var awb5 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Suzanne")).Id,
                    BookId = context.Books.First(b => b.Title.Equals("Jocurile Foamei")).Id
                };

                var awb6 = new AuthorsWriteBooks
                {
                    AuthorId = context.Authors.First(a => a.FirstName.Equals("Suzanne")).Id,
                    BookId = context.Books.First(b => b.Title.Equals("Mockingjay")).Id
                };

                context.AuthorsWriteBooks.Add(awb1);
                context.AuthorsWriteBooks.Add(awb2);
                context.AuthorsWriteBooks.Add(awb3);
                context.AuthorsWriteBooks.Add(awb4);
                context.AuthorsWriteBooks.Add(awb5);
                context.AuthorsWriteBooks.Add(awb6);
                context.SaveChanges();
            }
        }
    }
}
