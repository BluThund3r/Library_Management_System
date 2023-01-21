using Library_Management_System.Models;
using Library_Management_System.Models.DTOs.UserDTO;

namespace Library_Management_System.Services.UserService
{
    public interface IUserService
    {
        public UserResponseDTO Authenticate(UserRequestDTO requestDTO);
        public User GetById(Guid id);
        public User GetByUserName(string userName);
        public Task CreateUser(User user);
        public Task<List<User>> GetAllUsersAsync();

    }
}
