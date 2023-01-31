using AutoMapper;
using Library_Management_System.Helpers.JwtUtils;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs.UserDTO;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.UserRepository;
using System.Data;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Library_Management_System.Services.UserService
{
    public class UserService : IUserService
    {
        public readonly IUserRepository repo;
        public readonly IJwtUtils jwtUtils;
        public readonly IMapper mapper;

        public UserService(IUserRepository repo, IJwtUtils jwtUtils, IMapper mapper)
        {
            this.repo = repo;
            this.jwtUtils = jwtUtils;
            this.mapper = mapper;
        }

        public UserResponseDTO Authenticate(UserRequestDTO requestDTO)
        {
            var user = repo.GetByUserName(requestDTO.UserName);
            if (user == null || !BCryptNet.Verify(requestDTO.Password, user.PasswordHash))
                return null;

            var jwtToken = jwtUtils.GenerateJwtToken(user);
            return new UserResponseDTO(user, jwtToken);
        }

        public async Task CreateUserAsync(UserInfoDTO userDto)
        {
            var user = mapper.Map<User>(userDto);
            user.PasswordHash = BCryptNet.HashPassword(userDto.Password);
            await repo.CreateAsync(user);
            await repo.SaveAsync();
        }

        public void CreateUser(UserInfoDTO userDto)
        {
            var user = mapper.Map<User>(userDto);
            user.PasswordHash = BCryptNet.HashPassword(userDto.Password);
            repo.Create(user);
            repo.Save();
        }

        public UserInfoDTO GetById(Guid id)
        {
            var temp = repo.FindById(id);
            if(temp == null)
                return null;
            return mapper.Map<UserInfoDTO>(temp);
        }

        public UserInfoDTO GetByUserName(string userName)
        {
            return mapper.Map<UserInfoDTO>(repo.GetByUserName(userName));
        }

        public async Task<List<UserInfoDTO>> GetAllUsersAsync()
        {
            var users = await repo.GetAllAsync();
            var userDtos = new List<UserInfoDTO>();
            foreach(var elem in users)
            {
                var temp = mapper.Map<UserInfoDTO>(elem);
                userDtos.Add(temp);
            }

            return userDtos;
        }

        public void CreateRange(IEnumerable<UserInfoDTO> userDtos)
        {
            var users = new List<User>();
            foreach(var elem in userDtos)
            {
                users.Add(mapper.Map<User>(elem));
                users.Last().PasswordHash = BCryptNet.HashPassword(elem.Password);
            }

            repo.CreateRange(users);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<UserInfoDTO> userDtos)
        {
            var users = new List<User>();
            foreach (var elem in userDtos)
            {
                users.Add(mapper.Map<User>(elem));
                users.Last().PasswordHash = BCryptNet.HashPassword(elem.Password);
            }

            await repo.CreateRangeAsync(users);
            await repo.SaveAsync();
        }

        public void UpdateUser(UserInfoDTO userDto)
        {
            User user = mapper.Map<User>(userDto);
            user.PasswordHash = BCryptNet.HashPassword(userDto.Password);
            repo.Update(user);
            repo.Save();
        }

        public void UpdateUserRange(IEnumerable<UserInfoDTO> userDtos)
        {
            var users = new List<User>();
            foreach (var elem in userDtos)
            {
                users.Add(mapper.Map<User>(elem));
                users.Last().PasswordHash = BCryptNet.HashPassword(elem.Password);
            }

            repo.CreateRange(users);
            repo.Save();
        }

        public void DeleteUser(UserInfoDTO userDto)
        {
            repo.Delete(mapper.Map<User>(userDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<UserInfoDTO> userDtos)
        {
            var users = new List<User>();
            foreach(var elem in userDtos)
            {
                users.Add(mapper.Map<User>(elem));
            }

            repo.DeleteRange(users);
            repo.Save();
        }

        public UserInfoDTO GetByIdWithBorrowedBooks(Guid id)
        {
            var user = repo.GetByUserIdIncludeBooks(id);
            if (user == null)
                return null;
            return mapper.Map<UserInfoDTO>(user); 
        }

        public List<UserInfoDTO> GetByRole(string role)
        {
            var users = repo.GetByRole(role);
            var result = new List<UserInfoDTO>();
            foreach(var elem in users)
            {
                result.Add(mapper.Map<UserInfoDTO>(elem));
            }
            return result;
        }

        public List<UserInfoDTO> GetByLastName(string lastName)
        {
            var users = repo.GetUsersByLastName(lastName);
            var result = new List<UserInfoDTO>();
            foreach (var elem in users)
            {
                result.Add(mapper.Map<UserInfoDTO>(elem));
            }
            return result;
        }

        public List<UserInfoDTO> GetByFirstName(string firstName)
        {
            var users = repo.GetUsersByFirstName(firstName);
            var result = new List<UserInfoDTO>();
            foreach (var elem in users)
            {
                result.Add(mapper.Map<UserInfoDTO>(elem));
            }
            return result;
        }

        public UserInfoDTO GetByEmail(string email)
        {
            var temp = repo.GetUserByEmail(email);
            if (temp == null)
                return null;
            return mapper.Map<UserInfoDTO>(temp);
        }

        public List<Tuple<string, List<UserInfoDTO>>> GetUsersGroupedByCity()
        {
            var groups = repo.GetUsersGroupedByCity();
            var result = new List<Tuple<string, List<UserInfoDTO>>>();
            
            foreach(var group in groups)
            {
                var tempList = new List<UserInfoDTO>();
                foreach (var user in group)
                {
                    tempList.Add(mapper.Map<UserInfoDTO>(user));
                }
                result.Add(new Tuple<string, List<UserInfoDTO>>(group.Key, tempList));
            }

            return result;
        }
    }
}
