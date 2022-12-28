using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class SubscriptionCard : BaseEntity.BaseEntity
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
    }
}
