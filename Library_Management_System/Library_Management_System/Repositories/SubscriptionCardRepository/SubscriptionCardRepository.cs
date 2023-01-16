using Library_Management_System.Data;
using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.SubscriptionCardRepository
{
    public class SubscriptionCardRepository: GenericRepository<SubscriptionCard>, ISubscriptionCardRepository
    {
        public SubscriptionCardRepository(ApplicationContext context): base(context) { }

        public List<SubscriptionCard> GetAllOrderedByUserName(string userName)
        {
            return table.Join(context.Users, sc => sc.UserId, u => u.Id,
                (sc, u) => new { sc, u }).OrderBy(x => x.u.UserName).Select(x => x.sc).ToList();
        }

        public SubscriptionCard GetByUserId(Guid id)
        {
            return table.FirstOrDefault(x => x.UserId == id);
        }
    }
}
