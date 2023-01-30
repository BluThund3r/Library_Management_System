using Library_Management_System.Models;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Models.Enums;
using System.Dynamic;

namespace Library_Management_System.Services.UserService
{
    public interface IUserService
    {
        public Task<List<UserInfoDTO>> GetAllUsersAsync();
        public void CreateUser(UserInfoDTO userDto);
        public Task CreateUserAsync(UserInfoDTO userDto);
        public void CreateRange(IEnumerable<UserInfoDTO> userDtos);
        public Task CreateRangeAsync(IEnumerable<UserInfoDTO> userDtos);
        void UpdateUser(UserInfoDTO userDto);
        void UpdateUserRange(IEnumerable<UserInfoDTO> userDtos);
        void DeleteUser(UserInfoDTO userDto);
        void DeleteRange(IEnumerable<UserInfoDTO> userDtos);
        public UserResponseDTO Authenticate(UserRequestDTO requestDTO);
        public UserInfoDTO GetById(Guid id);
        public UserInfoDTO GetByUserName(string userName);
        public UserInfoDTO GetByIdWithBorrowedBooks(Guid id);
        public List<UserInfoDTO> GetByRole(string role);
        public List<UserInfoDTO> GetByLastName(string lastName);
        public List<UserInfoDTO> GetByFirstName(string firstName);
        public UserInfoDTO GetByEmail(string email);
        public List<Tuple<string, List<UserInfoDTO>>> GetUsersGroupedByCity();
    }
}
