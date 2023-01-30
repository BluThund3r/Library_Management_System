using Azure.Core;
using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Reflection.Emit;

namespace Library_Management_System.Repositories.BookCopyRepository
{
    public class BookCopyRepository: GenericRepository<BookCopy>, IBookCopyRepository
    {
        public BookCopyRepository(ApplicationContext context): base(context) { }

        public BookCopy FindCopyOfBookIfAvailable(Guid bookId)
        {
            var borrowedCopies = table.Join(context.UsersBorrowCopies, bc => bc.Id, ubc => ubc.CopyId,
                (bc, ubc) => new { bc, ubc }).Where(x => x.bc.BookId.Equals(bookId)).Select(x => x.bc).ToList();

            var allCopies = table.Where(bc => bc.BookId.Equals(bookId));

            return allCopies.FirstOrDefault(x => borrowedCopies.All(y => y.Id != x.Id));
        }

        public List<BookCopy> GetBookCopiesByBookTitle(string title)
        {
            var bookCopies = table.Join(context.Books, bc => bc.BookId, b => b.Id,
                (bc, b) => new { bc, b }).Where(x => x.b.Title.ToLower().Trim().Equals(title.ToLower().Trim())).Select(x => x.bc).ToList();
            return bookCopies;
        }

        public List<BookCopy> GetBookCopiesByBookTitleAndCoverType(string title, string coverType)
        {
            CoverType ct;
            if (!Enum.TryParse<CoverType>(coverType, true, out ct))
                return new List<BookCopy>();
            var bookCopies = GetBookCopiesByBookTitle(title).Where(bc => bc.CoverType.Equals(ct)).ToList();
            return bookCopies;
        }

        public List<BookCopy> GetBookCopiesByBookTitleOrderByPriceAsc(string title)
        {
            var bookCopies = GetBookCopiesByBookTitle(title).OrderBy(bc => bc.Price).ToList();
            return bookCopies;
        }

        public List<BookCopy> GetBookCopiesByBookTitleOrderByPriceDesc(string title)
        {
            var bookCopies = GetBookCopiesByBookTitle(title).OrderByDescending(bc => bc.Price).ToList();
            return bookCopies;
        }

        public List<BookCopy> GetBookCopiesByCoverType(string coverType)
        {
            CoverType ct;
            if (!Enum.TryParse<CoverType>(coverType, true, out ct))
                return new List<BookCopy>();
            return table.Where(x => x.CoverType.Equals(ct)).ToList();
        }

        public List<BookCopy> GetBookCopiesOrderedByPriceAsc()
        {
            return table.OrderBy(bc => bc.Price).ToList();
        }

        public List<BookCopy> GetBookCopiesOrderedByPriceDesc()
        {
            return table.OrderByDescending(bc => bc.Price).ToList();
        }
    }
}
