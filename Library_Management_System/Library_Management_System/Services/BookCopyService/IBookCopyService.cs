using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Library_Management_System.Services.BookCopyService
{
    public interface IBookCopyService
    {
        public void Create(BookCopyDTO bcDto);
        public Task CreateAsync(BookCopyDTO bcDto);
        public void CreateRange(IEnumerable<BookCopyDTO> bcDtos);
        public Task CreateRangeAsync(IEnumerable<BookCopyDTO> bcDtos);
        public void Delete(BookCopyDTO bcDto);
        public void DeleteRange(IEnumerable<BookCopyDTO> bcDtos);
        public BookCopyDTO GetById(Guid Id);
        public Task<BookCopyDTO> GetByIdAsync(Guid Id);
        public Task<List<BookCopyDTO>> GetAllAsync();
        public void Update(BookCopyDTO bcDto);
        public void UpdateRange(IEnumerable<BookCopyDTO> bcDtos);
        public List<BookCopyDTO> GetBookCopiesByBookTitle(string title);
        public List<BookCopyDTO> GetBookCopiesByBookTitleAndCoverType(string title, string coverType);
        public List<BookCopyDTO> GetBookCopiesByBookTitleOrderByPriceAsc(string title);
        public List<BookCopyDTO> GetBookCopiesByBookTitleOrderByPriceDesc(string title);
        public List<BookCopyDTO> GetBookCopiesByCoverType(string coverType);
        public List<BookCopyDTO> GetBookCopiesOrderedByPriceAsc();
        public List<BookCopyDTO> GetBookCopiesOrderedByPriceDesc();
        public BookCopyDTO GetCopyOfBookIfAnyAvailable(Guid bookId);
        public List<BookCopyDTO> GetAvailableCopiesOfBook(Guid bookId);
        public int GetAvailableNoCopiesOfBook(Guid bookId);
        public Task<bool> IsCopyBorrowed(Guid copyId);
        public int GetCountByBookId(Guid bookId);
        public List<BookCopyDTO> GetByBookId(Guid bookId);
    }
}
