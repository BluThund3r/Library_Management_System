using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;

namespace Library_Management_System.Services.UserBorrowsCopyService
{
    public interface IUserBorrowsCopyService
    {
        public void Create(UserBorrowsCopyDTO ubcDto);
        public Task CreateAsync(UserBorrowsCopyDTO ubcDto);
        public void CreateRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos);
        public Task CreateRangeAsync(IEnumerable<UserBorrowsCopyDTO> ubcDtos);
        public List<UserBorrowsCopyDTO> GetAll();
        public Task<List<UserBorrowsCopyDTO>> GetAllAsync();
        public List<UserBorrowsCopyDTO> GetAllByUserId(Guid userId);
        public UserBorrowsCopyDTO GetUserThatBorrowedCopy(Guid copyId);
        public List<UserBorrowsCopyDTO> GetAllValid();
        public List<UserBorrowsCopyDTO> GetAllInvalid();
        public List<UserBorrowsCopyDTO> GetAllInvalidByUserId(Guid userId);
        bool UserAlreadyBorrowedBook(Guid userId, Guid bookId);
        public UserBorrowsCopyDTO GetByUserIdAndCopyId(Guid userId, Guid copyId);
        public void Upate(UserBorrowsCopyDTO ubcDto);
        public void UpdateRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos);
        public void Delete(UserBorrowsCopyDTO ubcDto);
        public void DeleteRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos);
    }
}
