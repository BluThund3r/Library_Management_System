using Library_Management_System.Models.Enums;

namespace Library_Management_System.Models.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid PublisherId { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public Language Language { get; set; }
        public int NoPages { get; set; }

    }
}
