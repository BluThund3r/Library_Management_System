using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class Author : BaseEntity.BaseEntity
    {
        [Required(ErrorMessage = "Autorul trebuie sa aiba un prenume")]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Autorul trebuie sa aiba un nume")]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Range(10, 100)]
        public int Age { get; set; }

        public ICollection<AuthorsWriteBooks> AuthorsNameBooks { get; set; }

    }
}
