using Library_Management_System.Data;
using Library_Management_System.Models;

namespace Library_Management_System.Helpers.Seeders
{
    public class SubscriptionCardSeeder
    {
        public ApplicationContext context;

        public SubscriptionCardSeeder(ApplicationContext context)
        {
            this.context = context;
        }   

        public void SeedInitialSubscriptionCards()
        {
            if(!context.SubscriptionCards.Any())
            {
                var sc1 = new SubscriptionCard
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user1")).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2)
                };

                var sc2 = new SubscriptionCard
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user2")).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2)
                };

                var sc3 = new SubscriptionCard
                {
                    UserId = context.Users.FirstOrDefault(u => u.UserName.Equals("user3")).Id,
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddYears(2)
                };

                context.SubscriptionCards.Add(sc1);
                context.SubscriptionCards.Add(sc2);
                context.SubscriptionCards.Add(sc3);
                context.SaveChanges();
            }
        }
    }
}
