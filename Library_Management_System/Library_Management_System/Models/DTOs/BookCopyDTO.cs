using Library_Management_System.Models.Enums;

namespace Library_Management_System.Models.DTOs
{
    public class BookCopyDTO
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public CoverType CoverType { get; set; }
        public double Price { get; set; }

    }
}
