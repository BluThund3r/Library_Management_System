using Library_Management_System.Helpers.JwtUtils;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Repositories.UserRepository;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Library_Management_System.Services.UserService
{
    public class UserService : IUserService
    {
        public IUserRepository userRepository;
        public IJwtUtils jwtUtils;

        public UserService(IUserRepository userRepository, IJwtUtils jwtUtils)
        {
            this.userRepository = userRepository;
            this.jwtUtils = jwtUtils;
        }

        public UserResponseDTO Authenticate(UserRequestDTO requestDTO)
        {
            var user = userRepository.GetByUserName(requestDTO.UserName);
            if (user == null || BCryptNet.Verify(requestDTO.Password, user.PasswordHash))
                return null;

            var jwtToken = jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task CreateUser(User user)
        { 
            await userRepository.CreateAsync(user);
            await userRepository.SaveAsync();
        }

        public User GetById(Guid id)
        {
            return userRepository.FindById(id);
        }

        public User GetByUserName(string userName)
        {
            return userRepository.GetByUserName(userName);
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await userRepository.GetAllAsync();
        }
    }
}
