using Library_Management_System.Data;
using Library_Management_System.Models;
using BCryptNet = BCrypt.Net.BCrypt;

namespace Library_Management_System.Helpers.Seeders
{
    public class UserSeeder
    {
        public ApplicationContext context;

        public UserSeeder(ApplicationContext context)
        {
            this.context = context;
        }

        public void SeedInitialUsers()
        {
            if(!context.Users.Any())
            {
                var user1 = new User
                {
                    UserName = "user1",
                    FirstName = "user1FN",
                    LastName = "user1LN",
                    Age = 25,
                    Email = "something1@gmail.com",
                    PhoneNumber = "0846541",
                    City = "London",
                    Role = Models.Enums.Role.BasicUser,
                    PasswordHash = "$2b$10$oXP/MIqoIsQwqCFM0KuVGOZyi5wo4ptRpfyoUwmt/p0gaqqaBLHF."
                };

                var user2 = new User
                {
                    UserName = "user2",
                    FirstName = "user2FN",
                    LastName = "user2LN",
                    Age = 30,
                    Email = "something2@gmail.com",
                    PhoneNumber = "08465412",
                    City = "Bucharest",
                    Role = Models.Enums.Role.BasicUser,
                    PasswordHash = "$2b$10$ZFIXWh/RVDo1mCzIANQgGOSbMNPgWNi.p/neRSCN/VHeuQjJWE/Oa"
                };

                var user3 = new User
                {
                    UserName = "user3",
                    FirstName = "user3FN",
                    LastName = "user3LN",
                    Age = 20,
                    Email = "something3@gmail.com",
                    PhoneNumber = "08465413",
                    City = "New York City",
                    Role = Models.Enums.Role.BasicUser,
                    PasswordHash = "$2b$10$rK3V2R7wPezo6GYZBWbfhewy4EAKiJIqoj9g3QWvxhZQWAWV6gI.O"
                };

                var admin1 = new User
                {
                    UserName = "admin",
                    FirstName = "adminFN",
                    LastName = "adminLN",
                    Age = 35,
                    Email = "adminEmail@gmail.com",
                    PhoneNumber = "08465414",
                    City = "Budapest",
                    Role = Models.Enums.Role.Admin,
                    PasswordHash = "$2b$10$nn6kpwbw3jMxhpgrFzMdr.GkvyU4/JSR/f5Gn4kefjl.rhcK1bpJ."
                };

                var librarian1 = new User
                {
                    UserName = "librarian",
                    FirstName = "librarianFN",
                    LastName = "librarianLN",
                    Age = 25,
                    Email = "librarianEmail@gmail.com",
                    PhoneNumber = "153458141",
                    City = "Milan",
                    Role = Models.Enums.Role.Librarian,
                    PasswordHash = "$2b$10$yJ6nnI67LTpZubxjwRgvPubS6VyW/RYv0iHJgRDv.y0AcLn5369/u"
                };

                context.Users.Add(user1);
                context.Users.Add(user2);
                context.Users.Add(user3);
                context.Users.Add(admin1);
                context.Users.Add(librarian1);
                context.SaveChanges();
            }
        }
    }
}
