namespace Library_Management_System.Models.DTOs
{
    public class SubscriptionCardDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
