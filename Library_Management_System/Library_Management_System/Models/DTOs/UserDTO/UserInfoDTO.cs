using Library_Management_System.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models.DTOs.UserDTO
{
    public class UserInfoDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; } = "";
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public Role Role { get; set; }
    }
}
