using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Models.Enums;
using Library_Management_System.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.UserRepository
{
    public class UserRepository: GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationContext context): base(context) { }

        public List<User> GetByUserIdIncludeBooks(Guid id)
        {
            var result = table.Include("UserBorrowsCopy").Include("BookCopy").Include("Books")
                .Where(u => u.Id.Equals(id)).ToList();
            return result;
        }

        public User GetByUserName(string userName)
        {
            return table.FirstOrDefault(u => u.UserName.ToLower().Trim().Equals(userName.ToLower().Trim()));
        }

        public List<User> GetByRole(string role)
        {
            Role rl;
            if (!Enum.TryParse<Role>(role, true, out rl))
                return new List<User>();
            return table.Where(u => u.Role.Equals(role)).ToList();
        }

        public List<User> GetUsersOlderThan(int age)
        {
            return table.Where(u => u.Age >= age).ToList();
        }

        public List<User> GetUsersByLastName(string lastName)
        {
            return table.Where(u => u.LastName.ToLower().Trim().Equals(lastName.ToLower().Trim())).ToList();  
        }

        public List<User> GetUsersByFirstName(string firstName)
        {
            return table.Where(u => u.FirstName.ToLower().Trim().Equals(firstName.ToLower().Trim())).ToList();
        }

        public User GetUserByEmail(string email)
        {
            return table.FirstOrDefault(u => u.Email.ToLower().Trim().Equals(email.ToLower().Trim()));
        }

        public List<IGrouping<string, User>> GetUsersGroupedByCity()
        {
            return table.GroupBy(u => u.City).ToList();
        }
    }
}
