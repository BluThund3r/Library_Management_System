using AutoMapper;
using Library_Management_System.Models;
using Library_Management_System.Models.DTOs;
using Library_Management_System.Repositories.UserBorrowsCopyRepository;

namespace Library_Management_System.Services.UserBorrowsCopyService
{
    public class UserBorrowsCopyService: IUserBorrowsCopyService
    {
        public readonly IUserBorrowsCopyRepository repo;
        public readonly IMapper mapper;

        public UserBorrowsCopyService(IUserBorrowsCopyRepository repo, IMapper mapper)
        {
            this.repo = repo;
            this.mapper = mapper;
        }

        public void Create(UserBorrowsCopyDTO ubcDto)
        {
            repo.Create(mapper.Map<UserBorrowsCopy>(ubcDto));
            repo.Save();
        }

        public async Task CreateAsync(UserBorrowsCopyDTO ubcDto)
        {
           await repo.CreateAsync(mapper.Map<UserBorrowsCopy>(ubcDto));
           await repo.SaveAsync();
        }

        public void CreateRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos)
        {
            var ubcs = new List<UserBorrowsCopy>();
            foreach(var elem in ubcDtos)
            {
                ubcs.Add(mapper.Map<UserBorrowsCopy>(elem));
            }

            repo.CreateRange(ubcs);
            repo.Save();
        }

        public async Task CreateRangeAsync(IEnumerable<UserBorrowsCopyDTO> ubcDtos)
        {
            var ubcs = new List<UserBorrowsCopy>();
            foreach (var elem in ubcDtos)
            {
                ubcs.Add(mapper.Map<UserBorrowsCopy>(elem));
            }

            await repo.CreateRangeAsync(ubcs);
            await repo.SaveAsync();
        }

        public void Delete(UserBorrowsCopyDTO ubcDto)
        {
            repo.Delete(mapper.Map<UserBorrowsCopy>(ubcDto));
            repo.Save();
        }

        public void DeleteRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos)
        {
            var ubcs = new List<UserBorrowsCopy>();
            foreach (var elem in ubcDtos)
            {
                ubcs.Add(mapper.Map<UserBorrowsCopy>(elem));
            }

            repo.DeleteRange(ubcs);
            repo.Save();
        }

        public List<UserBorrowsCopyDTO> GetAll()
        {
            var ubcs = repo.GetAll();
            var result = new List<UserBorrowsCopyDTO>();
            foreach(var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public async Task<List<UserBorrowsCopyDTO>> GetAllAsync()
        {
            var ubcs = await repo.GetAllAsync();
            var result = new List<UserBorrowsCopyDTO>();
            foreach (var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public List<UserBorrowsCopyDTO> GetAllByUserId(Guid userId)
        {
            var ubcs = repo.GetAllByUserId(userId);
            var result = new List<UserBorrowsCopyDTO>();
            foreach (var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public List<UserBorrowsCopyDTO> GetAllInvalid()
        {
            var ubcs = repo.GetAllInvalid();
            var result = new List<UserBorrowsCopyDTO>();
            foreach (var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public List<UserBorrowsCopyDTO> GetAllInvalidByUserId(Guid userId)
        {
            var ubcs = repo.GetAllInvalidByUserId(userId);
            var result = new List<UserBorrowsCopyDTO>();
            foreach (var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public List<UserBorrowsCopyDTO> GetAllValid()
        {
            var ubcs = repo.GetAllValid();
            var result = new List<UserBorrowsCopyDTO>();
            foreach (var elem in ubcs)
            {
                result.Add(mapper.Map<UserBorrowsCopyDTO>(elem));
            }

            return result;
        }

        public UserBorrowsCopyDTO GetUserThatBorrowedCopy(Guid copyId)
        {
            var temp = repo.FindUserWithCopy(copyId);
            if (temp == null)
                return null;
            return mapper.Map<UserBorrowsCopyDTO>(temp);
        }

        public void Upate(UserBorrowsCopyDTO ubcDto)
        {
            repo.Update(mapper.Map<UserBorrowsCopy>(ubcDto));
            repo.Save();
        }

        public void UpdateRange(IEnumerable<UserBorrowsCopyDTO> ubcDtos)
        {
            var ubcs = new List<UserBorrowsCopy>();
            foreach(var elem in ubcDtos)
            {
                ubcs.Add(mapper.Map<UserBorrowsCopy>(elem));
            }

            repo.UpdateRange(ubcs);
            repo.Save();
        }
    }
}
