using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;

namespace Library_Management_System.Services.BookService
{
    public interface IBookService
    {
        public void Create(BookDTO bookDto);
        public Task CreateAsync(BookDTO bookDTO);
        public void CreateRange(IEnumerable<BookDTO> bookDtos);
        public Task CreateRangeAsync(IEnumerable<BookDTO> bookDtos);
        public void Delete(BookDTO bookDTO);
        public void DeleteRange(IEnumerable<BookDTO> bookDTOs);
        public BookDTO GetById(Guid id);
        public Task<BookDTO> GetByIdAsync(Guid id);
        public Task<List<BookDTO>> GetAllAsync();
        public void Update(BookDTO bookDTO);
        public void UpdateRange(IEnumerable<BookDTO> bookDTOs);
        public List<BookDTO> GetAllBooksIncludeBookCopy();
        public List<BookDTO> GetBooksByGenreIncludeBookCopy(string genre);
        public List<BookDTO> GetBooksByLanguage(string language);
        public List<BookDTO> GetBooksWithMorePagesThan(int pages);
        public List<BookDTO> GetBooksFromPublisher(Guid publisherId);
        public List<BookDTO> GetBooksByTitle(string title);
        public List<BookDTO> GetBooksOrderedByTitleAsc();
        public List<BookDTO> GetBooksOrderedByTitleDesc();
        public List<BookDTO> GetBooksReleasedAfterYear(int year);
        public bool BookHasCopiesBorrowed(Guid bookId);
    }
}
