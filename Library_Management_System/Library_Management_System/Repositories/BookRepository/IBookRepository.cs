using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.BookRepository
{
    public interface IBookRepository: IGenericRepository<Book>
    {
        public List<Book> GetAllBooksIncludeBookCopy();
        public List<Book> GetBooksByGenreIncludeBookCopy(string genre);
        public List<Book> GetBooksReleasedAfterYear(int year);
        public List<Book> GetBooksByLanguage(string language);
        public List<Book> GetBooksByMinPages(int pages);
        public List<Book> GetBooksByPublisher(Guid publisherId);
        public List<Book> GetBooksByTitle(string title);
        public List<Book> GetBooksOrderedByTitleAsc();
        public List<Book> GetBooksOrderedByTitleDesc();

    }
}
