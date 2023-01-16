using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.BookRepository
{
    public class BookRepository: GenericRepository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context): base(context) { }

        public List<Book> GetAllBooksIncludeBookCopy()
        {
            return table.Include(b => b.BookCopies).ToList();
        }

        public List<Book> GetBooksByGenreIncludeBookCopy(string genre)
        {
            Genre gr;
            if (!Enum.TryParse<Genre>(genre, true, out gr))
                return new List<Book>();
            var books = table.Include(b => b.BookCopies).Where(b => b.Genre.Equals(gr)).ToList();
            return books;
        }

        public List<Book> GetBooksByLanguage(string language)
        {
            Language l;
            if (!Enum.TryParse<Language>(language, true, out l))
                return new List<Book>();
            return table.Where(b => b.Language.Equals(language)).ToList();
        }

        public List<Book> GetBooksByMinPages(int pages)
        {
            return table.Where(b => b.NoPages >= pages).ToList();
        }

        public List<Book> GetBooksByPublisher(Guid publisherId)
        {
            return table.Where(b => b.PublisherId.Equals(publisherId)).ToList();
        }

        public List<Book> GetBooksByTitle(string title)
        {
            return table.Where(b => b.Title.Equals(title)).ToList();
        }

        public List<Book> GetBooksOrderedByTitleAsc()
        {
            return table.OrderBy(b => b.Title).ToList();
        }

        public List<Book> GetBooksOrderedByTitleDesc()
        {
            return table.OrderByDescending(b => b.Title).ToList();
        }

        public List<Book> GetBooksReleasedAfterYear(int year)
        {
            var afterDate = new DateTime(year, 1, 1);
            return table.Where(b => DateTime.Compare(b.ReleaseDate, afterDate) >= 0).ToList();
        }
    }
}
