using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Helpers.Seeders
{
    public class BookSeeder
    {
        public readonly ApplicationContext context;

        public BookSeeder(ApplicationContext context)
        {
            this.context = context;
        }

        public void SeedInitialBooks()
        {
            if(!context.Books.Any())
            {
                var book1 = new Book
                {
                    Title = "Red Rising",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("paladin")).Id,
                    ReleaseDate = new DateTime(2014, 1, 28),
                    Genre = Models.Enums.Genre.SF,
                    Language = Models.Enums.Language.English,
                    NoPages = 512
                };

                var book2 = new Book
                {
                    Title = "Golden Son",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("paladin")).Id,
                    ReleaseDate = new DateTime(2015, 1, 6),
                    Genre = Models.Enums.Genre.SF,
                    Language = Models.Enums.Language.English,
                    NoPages = 610
                };

                var book3 = new Book
                {
                    Title = "Elias Si Spioana Carturarilor: O torta in noapte",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("youngart")).Id,
                    ReleaseDate = new DateTime(2016, 8, 30),
                    Genre = Models.Enums.Genre.Fantasy,
                    Language = Models.Enums.Language.Romanian,
                    NoPages = 456
                };

                var book4 = new Book
                {
                    Title = "Elias Si Spioana Carturarilor: Focul din cenusa",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("youngart")).Id,
                    ReleaseDate = new DateTime(2015, 4, 28),
                    Genre = Models.Enums.Genre.Fantasy,
                    Language = Models.Enums.Language.Romanian,
                    NoPages = 531
                };

                var book5 = new Book
                {
                    Title = "Jocurile Foamei",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("armada")).Id,
                    ReleaseDate = new DateTime(2012, 10, 10),
                    Genre = Models.Enums.Genre.Fantasy,
                    Language = Models.Enums.Language.Romanian,
                    NoPages = 315
                };

                var book6 = new Book
                {
                    Title = "Mockingjay",
                    PublisherId = context.Publishers.First(p => p.Name.ToLower().Equals("armada")).Id,
                    ReleaseDate = new DateTime(2014, 11, 21),
                    Genre = Models.Enums.Genre.Fantasy,
                    Language = Models.Enums.Language.English,
                    NoPages = 411
                };

                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);
                context.Books.Add(book4);
                context.Books.Add(book5);
                context.Books.Add(book5);
                context.SaveChanges();
            }
        }
    }
}
