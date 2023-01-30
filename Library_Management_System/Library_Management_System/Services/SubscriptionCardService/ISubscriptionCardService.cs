using Library_Management_System.Models.DTOs;

namespace Library_Management_System.Services.SubscriptionCardService
{
    public interface ISubscriptionCardService
    {
        public void Create(SubscriptionCardDTO scDto);
        public Task CreateAsync(SubscriptionCardDTO scDto);
        public void CreateRange(IEnumerable<SubscriptionCardDTO> scDtos);
        public Task CreateRangeAsync(IEnumerable<SubscriptionCardDTO> scDtos);
        public void Delete(SubscriptionCardDTO scDto);
        public void DeleteRange(IEnumerable<SubscriptionCardDTO> scDtos);
        public SubscriptionCardDTO GetById(Guid id);
        public Task<SubscriptionCardDTO> GetByIdAsync (Guid id);
        public Task<List<SubscriptionCardDTO>> GetAllAsync();
        public void Update(SubscriptionCardDTO scDto);
        public void UpdateRange(IEnumerable<SubscriptionCardDTO> scDtos);
        public List<SubscriptionCardDTO> GetAllOrderedByUserName();
        public SubscriptionCardDTO GetByUserId(Guid id);
    }
}
