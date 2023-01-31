using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.BookRepository;
using Library_Management_System.Services.BookCopyService;

namespace Library_Management_System.Services.BookService
{
    public class BookService : IBookService
    {
        public readonly IBookRepository repo;
        public readonly IBookCopyService bookCopyService;
        public readonly IMapper mapper;

        public BookService(IBookRepository repo, IMapper mapper, IBookCopyService bookCopyService)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.bookCopyService = bookCopyService;
        }

        public bool BookHasCopiesBorrowed(Guid bookId)
        {
            var allCopies = bookCopyService.GetByBookId(bookId);
            var availableCopies = bookCopyService.GetAvailableCopiesOfBook(bookId);
            return allCopies.Count() != availableCopies.Count();
        }

        public void Create(BookDTO bookDto)
        {
            repo.Create(mapper.Map<Book>(bookDto));
            repo.Save();
        }

        public async Task CreateAsync(BookDTO bookDTO)
        {
            await repo.CreateAsync(mapper.Map<Book>(bookDTO));
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<BookDTO> bookDtos)
        {
            var books = new List<Book>();
            foreach(var elem in bookDtos)
            {
                books.Add(mapper.Map<Book>(elem));
            }

            repo.CreateRange(books);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<BookDTO> bookDtos)
        {
            var books = new List<Book>();
            foreach (var elem in bookDtos)
            {
                books.Add(mapper.Map<Book>(elem));
            }

            await repo.CreateRangeAsync(books);
            await repo.SaveAsync();
        }

        public void Delete(BookDTO bookDTO)
        {
            repo.Delete(mapper.Map<Book>(bookDTO));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<BookDTO> bookDTOs)
        {
            var books = new List<Book>();
            foreach (var elem in bookDTOs)
            {
                books.Add(mapper.Map<Book>(elem));
            }

            repo.DeleteRange(books);
            repo.Save();
        }

        public async Task<List<BookDTO>> GetAllAsync()
        {
            var books = await repo.GetAllAsync();
            var bookDtos = new List<BookDTO>();
            foreach(var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetAllBooksIncludeBookCopy()
        {
            var books = repo.GetAllBooksIncludeBookCopy();
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksByGenreIncludeBookCopy(string genre)
        {
            var books = repo.GetBooksByGenreIncludeBookCopy(genre);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksByLanguage(string language)
        {
            var books = repo.GetBooksByLanguage(language);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksByTitle(string title)
        {
            var books = repo.GetBooksByTitle(title);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksFromPublisher(Guid publisherId)
        {
            var books = repo.GetBooksByPublisher(publisherId);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksOrderedByTitleAsc()
        {
            var books = repo.GetBooksOrderedByTitleAsc();
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksOrderedByTitleDesc()
        {
            var books = repo.GetBooksOrderedByTitleDesc();
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksReleasedAfterYear(int year)
        {
            var books = repo.GetBooksReleasedAfterYear(year);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public List<BookDTO> GetBooksWithMorePagesThan(int pages)
        {
            var books = repo.GetBooksByMinPages(pages);
            var bookDtos = new List<BookDTO>();
            foreach (var elem in books)
            {
                bookDtos.Add(mapper.Map<BookDTO>(elem));
            }

            return bookDtos;
        }

        public BookDTO GetById(Guid id)
        {
            var temp = repo.FindById(id);
            if (temp == null)
                return null;
            return mapper.Map<BookDTO>(temp);
        }

        public async Task<BookDTO> GetByIdAsync(Guid id)
        {
            var temp = await repo.FindByIdAsync(id);
            if (temp == null)
                return null;
            return mapper.Map<BookDTO>(temp);
        }

        public void Update(BookDTO bookDTO)
        {
            repo.Update(mapper.Map<Book>(bookDTO));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<BookDTO> bookDTOs)
        {
            var books = new List<Book>();
            foreach(var elem in bookDTOs)
            {
                books.Add(mapper.Map<Book>(elem));
            }

            repo.UpdateRange(books);
            repo.Save();
        }
    }
}
