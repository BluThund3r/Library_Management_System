namespace Library_Management_System.Models
{
    public class AuthorsWriteBooks
    {
        public Guid AuthorId { get; set; }
        public Guid BookId { get; set; }
        public Author Author { get; set; }
        public Book Book { get; set; }
    }
}
