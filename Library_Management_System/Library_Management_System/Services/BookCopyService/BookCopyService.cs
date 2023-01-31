using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.BookCopyRepository;
using Library_Management_System.Repositories.UserBorrowsCopyRepository;
using System.Linq.Expressions;

namespace Library_Management_System.Services.BookCopyService
{
    public class BookCopyService: IBookCopyService
    {
        public readonly IBookCopyRepository repo;
        public readonly IUserBorrowsCopyRepository ubcService;
        public readonly IMapper mapper;

        public BookCopyService(IBookCopyRepository repo, IMapper mapper, IUserBorrowsCopyRepository ubcService)
        {
            this.repo = repo;
            this.mapper = mapper;
            this.ubcService = ubcService;
        }

        public void Create(BookCopyDTO bcDto)
        {
            repo.Create(mapper.Map<BookCopy>(bcDto));
            repo.Save();
        }

        public async Task CreateAsync(BookCopyDTO bcDto)
        {
            await repo.CreateAsync(mapper.Map<BookCopy>(bcDto));
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<BookCopyDTO> bcDtos)
        {
            var bcs = new List<BookCopy>();
            foreach(var elem in bcDtos)
            {
                bcs.Add(mapper.Map<BookCopy>(elem));
            }
            repo.CreateRange(bcs);
            repo.Save();

        }

        public async Task CreateRangeAsync(IEnumerable<BookCopyDTO> bcDtos)
        {
            var bcs = new List<BookCopy>();
            foreach (var elem in bcDtos)
            {
                bcs.Add(mapper.Map<BookCopy>(elem));
            }
            await repo.CreateRangeAsync(bcs);
            await repo.SaveAsync();
        }

        public void Delete(BookCopyDTO bcDto)
        {
            repo.Delete(mapper.Map<BookCopy>(bcDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<BookCopyDTO> bcDtos)
        {
            var bcs = new List<BookCopy>();
            foreach (var elem in bcDtos)
            {
                bcs.Add(mapper.Map<BookCopy>(elem));
            }
            repo.DeleteRange(bcs);
            repo.Save();
        }

        public async Task<List<BookCopyDTO>> GetAllAsync()
        {
            var bcs = await repo.GetAllAsync();
            var bcDtos = new List<BookCopyDTO>();
            foreach(var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetAvailableCopiesOfBook(Guid bookId)
        {
            var copies = repo.GetAvailableCopiesOfBook(bookId);
            var copyDtos = new List<BookCopyDTO>();
            foreach(var elem in copies)
            {
                copyDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }
            return copyDtos;
        }

        public int GetAvailableNoCopiesOfBook(Guid bookId)
        {
            var bookCopies = GetAvailableCopiesOfBook(bookId);
            return bookCopies.Count();
        }

        public List<BookCopyDTO> GetBookCopiesByBookTitle(string title)
        {
            var bcs = repo.GetBookCopiesByBookTitle(title);
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesByBookTitleAndCoverType(string title, string coverType)
        {
            var bcs = repo.GetBookCopiesByBookTitleAndCoverType(title, coverType);
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesByBookTitleOrderByPriceAsc(string title)
        {
            var bcs = repo.GetBookCopiesByBookTitleOrderByPriceAsc(title);
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesByBookTitleOrderByPriceDesc(string title)
        {
            var bcs = repo.GetBookCopiesByBookTitleOrderByPriceDesc(title);
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesByCoverType(string coverType)
        {
            var bcs = repo.GetBookCopiesByCoverType(coverType);
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesOrderedByPriceAsc()
        {
            var bcs = repo.GetBookCopiesOrderedByPriceAsc();
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetBookCopiesOrderedByPriceDesc()
        {
            var bcs = repo.GetBookCopiesOrderedByPriceDesc();
            var bcDtos = new List<BookCopyDTO>();
            foreach (var elem in bcs)
            {
                bcDtos.Add(mapper.Map<BookCopyDTO>(elem));
            }

            return bcDtos;
        }

        public List<BookCopyDTO> GetByBookId(Guid bookId)
        {
            var books = repo.FindByBookId(bookId);
            var result = new List<BookCopyDTO>();
            foreach(var elem in books)
            {
                result.Add(mapper.Map<BookCopyDTO>(elem));
            }
            return result;
        }

        public BookCopyDTO GetById(Guid Id)
        {
            var temp = repo.FindById(Id);
            if (temp == null)
                return null;
            return mapper.Map<BookCopyDTO>(temp);
        }

        public async Task<BookCopyDTO> GetByIdAsync(Guid Id)
        {
            var temp = await repo.FindByIdAsync(Id);
            if (temp == null)
                return null;
            return mapper.Map<BookCopyDTO>(temp);
        }

        public BookCopyDTO GetCopyOfBookIfAnyAvailable(Guid bookId)
        {
            var result = repo.FindCopyOfBookIfAvailable(bookId);
            if (result == null)
                return null;
            return mapper.Map<BookCopyDTO>(result);
        }

        public int GetCountByBookId(Guid bookId)
        {
            return GetByBookId(bookId).Count();
        }

        public async Task<bool> IsCopyBorrowed(Guid copyId)
        {
            var borrowedCopies = await ubcService.GetAllAsync();
            return borrowedCopies.Any(bc => bc.CopyId.Equals(copyId));
        }

        public void Update(BookCopyDTO bcDto)
        {
            repo.Update(mapper.Map<BookCopy>(bcDto));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<BookCopyDTO> bcDtos)
        {
            var bcs = new List<BookCopy>();
            foreach(var elem in bcDtos)
            {
                bcs.Add(mapper.Map<BookCopy>(elem));
            }

            repo.UpdateRange(bcs);
            repo.Save();
        }
    }
}
