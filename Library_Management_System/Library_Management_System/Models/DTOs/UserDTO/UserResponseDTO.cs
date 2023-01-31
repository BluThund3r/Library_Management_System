using Library_Management_System.Models.Enums;

namespace Library_Management_System.Models.DTOs.UserDTO
{
    public class UserResponseDTO
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Token { get; set; }
        public Role Role { get; set; }

        public UserResponseDTO(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            UserName = user.UserName;
            Email = user.Email;
            Role = user.Role;
            Token = token;
        }
    }
}
