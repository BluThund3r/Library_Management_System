using Library_Management_System.Models.Enums;
using Microsoft.AspNetCore.Mvc.Razor;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Book: BaseEntity.BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        public Guid PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public Genre Genre { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Numarul de pagini trebuie sa fie pozitiv")]
        public int NoPages { get; set; }

        public ICollection<AuthorsWriteBooks> AuthorsWriteBooks { get; set; }

        public ICollection<BookCopy> BookCopies { get; set; }
    }
}
