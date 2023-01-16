using Library_Management_System.Models.Enums;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library_Management_System.Models
{ 
    public class User : BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(30)]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9_]{7,29}$", ErrorMessage = "Unele caractere nu sunt permise, folositi doar litere, cifre si _, incepand cu o litera")]
        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Range(14, 110)]
        public int Age { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$",
            ErrorMessage = "Format de email incorect")]
        public string Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string City { get; set; }

        [Required]
        public Role Role { get; set; }

        public SubscriptionCard? Card { get; set; }

        public ICollection<UserBorrowsCopy> UsersBorrowCopies { get; set; }

        [JsonIgnore]
        public string PasswordHash { get; set; }
    }
}
