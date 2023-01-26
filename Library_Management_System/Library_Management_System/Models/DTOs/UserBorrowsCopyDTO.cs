namespace Library_Management_System.Models.DTOs
{
    public class UserBorrowsCopyDTO
    {
        public Guid UserId { get; set; }
        public Guid CopyId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
