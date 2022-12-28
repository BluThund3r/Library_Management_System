using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class UserBorrowsCopy
    {
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid CopyId { get; set; }
        public BookCopy Copy { get; set; }

        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }  
    }
}
