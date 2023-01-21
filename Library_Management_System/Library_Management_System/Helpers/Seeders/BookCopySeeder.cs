using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Helpers.Seeders
{
    public class BookCopySeeder
    {
        public readonly ApplicationContext context;

        public BookCopySeeder(ApplicationContext context)
        {
            this.context = context;
        }   

        public void SeedInitialBookCopies()
        {
            if(!context.BookCopies.Any())
            {
                var bc1 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Red Rising")).Id,
                    CoverType = Models.Enums.CoverType.HardCover,
                    Price = 51.5
                };

                var bc2 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Golden Son")).Id,
                    CoverType = Models.Enums.CoverType.PaperBack,
                    Price = 60
                };

                var bc3 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Elias Si Spioana Carturarilor: O torta in noapte")).Id,
                    CoverType = Models.Enums.CoverType.HardCover,
                    Price = 56.3
                };

                var bc4 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Elias Si Spioana Carturarilor: Focul din cenusa")).Id,
                    CoverType = Models.Enums.CoverType.PaperBack,
                    Price = 68
                };

                var bc5 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Jocurile Foamei")).Id,
                    CoverType = Models.Enums.CoverType.PaperBack,
                    Price = 35
                };

                var bc6 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Mockingjay")).Id,
                    CoverType = Models.Enums.CoverType.PaperBack,
                    Price = 38
                };

                var bc7 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Red Rising")).Id,
                    CoverType = Models.Enums.CoverType.PaperBack,
                    Price = 47
                };


                var bc8 = new BookCopy
                {
                    BookId = context.Books.FirstOrDefault(b => b.Title.Equals("Golden Son")).Id,
                    CoverType = Models.Enums.CoverType.HardCover,
                    Price = 59
                };


                context.BookCopies.Add(bc1);
                context.BookCopies.Add(bc2);
                context.BookCopies.Add(bc4);
                context.BookCopies.Add(bc5);
                context.BookCopies.Add(bc6);
                context.BookCopies.Add(bc7);
                context.BookCopies.Add(bc8);
                context.BookCopies.Add(bc3);
                context.SaveChanges();
            }
        }
    }
}
