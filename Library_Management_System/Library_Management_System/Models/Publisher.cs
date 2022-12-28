using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Publisher : BaseEntity.BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
