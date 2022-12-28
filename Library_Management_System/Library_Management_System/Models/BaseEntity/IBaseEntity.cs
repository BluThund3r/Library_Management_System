using Microsoft.Identity.Client;

namespace Library_Management_System.Models.BaseEntity
{
    public interface IBaseEntity
    {
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; } 
    }
}
