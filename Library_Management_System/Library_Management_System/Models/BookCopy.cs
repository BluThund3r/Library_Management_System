using Library_Management_System.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BookCopy: BaseEntity.BaseEntity
    {
        [Required]
        public Guid BookId { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public CoverType CoverType { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Pretul trebuie sa fie pozitiv")]
        public double Price { get; set; }

        public ICollection<UserBorrowsCopy> UsersBorrowCopies { get; set; }
    }
}
