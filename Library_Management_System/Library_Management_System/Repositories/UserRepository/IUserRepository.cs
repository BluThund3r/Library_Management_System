using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.UserRepository
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public User GetByUserIdIncludeBooks(Guid id);
        public User GetByUserName(string userName);
        public List<User> GetByRole(string role);
        public List<User> GetUsersOlderThan(int age);
        public List<User> GetUsersByLastName(string lastName);
        public List<User> GetUsersByFirstName(string firstName);
        public User GetUserByEmail(string email);
        public List<IGrouping<string, User>> GetUsersGroupedByCity();
    }
}
