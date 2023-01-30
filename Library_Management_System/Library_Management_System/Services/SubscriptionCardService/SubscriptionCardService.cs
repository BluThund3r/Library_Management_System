using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.SubscriptionCardRepository;
using Microsoft.AspNetCore.Components.Forms;

namespace Library_Management_System.Services.SubscriptionCardService
{
    public class SubscriptionCardService: ISubscriptionCardService
    {
        public readonly ISubscriptionCardRepository repo;
        public readonly IMapper mapper;

        public SubscriptionCardService(ISubscriptionCardRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(SubscriptionCardDTO scDto)
        {
            repo.Create(mapper.Map<SubscriptionCard>(scDto));
            repo.Save();
        }

        public async Task CreateAsync(SubscriptionCardDTO scDto)
        {
            await repo.CreateAsync(mapper.Map<SubscriptionCard>(scDto));
            await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<SubscriptionCardDTO> scDtos)
        {
            var scs = new List<SubscriptionCard>();
            foreach(var elem in scDtos)
            {
                scs.Add(mapper.Map<SubscriptionCard>(elem));
            }

            repo.CreateRange(scs);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<SubscriptionCardDTO> scDtos)
        {
            var scs = new List<SubscriptionCard>();
            foreach(var elem in scDtos)
            {
                scs.Add(mapper.Map<SubscriptionCard>(elem));
            }

            await repo.CreateRangeAsync(scs);
            await repo.SaveAsync();
        }

        public void Delete(SubscriptionCardDTO scDto)
        {
            repo.Delete(mapper.Map<SubscriptionCard>(scDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<SubscriptionCardDTO> scDtos)
        {
            var scs = new List<SubscriptionCard>();
            foreach(var elem in scDtos)
            {
                scs.Add(mapper.Map<SubscriptionCard>(elem));
            }

            repo.DeleteRange(scs);
            repo.Save();
        }

        public async Task<List<SubscriptionCardDTO>> GetAllAsync()
        {
            var scs = await repo.GetAllAsync();
            var scDtos = new List<SubscriptionCardDTO>();
            foreach(var elem in scs)
            {
                scDtos.Add(mapper.Map<SubscriptionCardDTO>(elem));
            }

            return scDtos;
        }

        public List<SubscriptionCardDTO> GetAllOrderedByUserName()
        {
            var scs = repo.GetAllOrderedByUserName();
            var scDtos = new List<SubscriptionCardDTO>();
            foreach (var elem in scs)
            {
                scDtos.Add(mapper.Map<SubscriptionCardDTO>(elem));
            }

            return scDtos;
        }

        public SubscriptionCardDTO GetById(Guid id)
        {
            var temp = repo.FindById(id);
            if (temp == null)
                return null;
            return mapper.Map<SubscriptionCardDTO>(temp);
        }

        public async Task<SubscriptionCardDTO> GetByIdAsync(Guid id)
        {
            var temp = await repo.FindByIdAsync(id);
            if (temp == null)
                return null;
            return mapper.Map<SubscriptionCardDTO>(temp);
        }

        public SubscriptionCardDTO GetByUserId(Guid id)
        {
            var temp = repo.GetByUserId(id);
            if (temp == null)
                return null;
            return mapper.Map<SubscriptionCardDTO>(temp);
        }

        public void Update(SubscriptionCardDTO scDto)
        {
            repo.Update(mapper.Map<SubscriptionCard>(scDto));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<SubscriptionCardDTO> scDtos)
        {
            var scs = new List<SubscriptionCard>();
            foreach(var elem in scDtos)
            {
                scs.Add(mapper.Map<SubscriptionCard>(elem));
            }

            repo.UpdateRange(scs);
            repo.Save();
        }
    }
}
