using Library_Management_System.Models;
using Library_Management_System.Repositories.GenericRepository;

namespace Library_Management_System.Repositories.SubscriptionCardRepository
{
    public interface ISubscriptionCardRepository: IGenericRepository<SubscriptionCard>
    {
        public SubscriptionCard GetByUserId(Guid id);
        public List<SubscriptionCard> GetAllOrderedByUserName(string userName);
    }
}
