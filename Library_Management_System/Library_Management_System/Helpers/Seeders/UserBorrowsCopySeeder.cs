using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Helpers.Seeders
{
    public class UserBorrowsCopySeeder
    {
        public readonly ApplicationContext context;

        public UserBorrowsCopySeeder(ApplicationContext _context)
        {
            context = _context;
        }

        public void SeedInitialUserBorrowsCopies()
        {
            if (!context.UsersBorrowCopies.Any())
            {
                var ubc1 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user1")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(51.5)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                var ubc2 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user1")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(38)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                var ubc3 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user2")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(56.3)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                var ubc4 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user2")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(60)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                var ubc5 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user2")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(68)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                var ubc6 = new UserBorrowsCopy
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user3")).Id,
                    CopyId = context.BookCopies.FirstOrDefault(bc => bc.Price.Equals(47)).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddDays(14)
                };

                context.UsersBorrowCopies.Add(ubc1);
                context.UsersBorrowCopies.Add(ubc2);
                context.UsersBorrowCopies.Add(ubc3);
                context.UsersBorrowCopies.Add(ubc4);
                context.UsersBorrowCopies.Add(ubc5);
                context.UsersBorrowCopies.Add(ubc6);
                context.SaveChanges();
            }
        }
    }
}
