﻿using Library_Management_System.Data;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.UserBorrowsCopyRepository
{
    public class UserBorrowsCopyRepository : IUserBorrowsCopyRepository
    {

        protected readonly ApplicationContext context;
        protected readonly DbSet<UserBorrowsCopy> table;

        public UserBorrowsCopyRepository(ApplicationContext context_)
        {
            context = context_;
            table = context.Set<UserBorrowsCopy>();
        }
        public void Create(UserBorrowsCopy ubc)
        {
            table.Add(ubc);
        }

        public async Task CreateAsync(UserBorrowsCopy ubc)
        {
            await table.AddAsync(ubc);
        }

        public void CreateRange(IEnumerable<UserBorrowsCopy> ubcs)
        {
            table.AddRange(ubcs);
        }

        public async Task CreateRangeAsync(IEnumerable<UserBorrowsCopy> ubcs)
        {
            await table.AddRangeAsync(ubcs);
        }

        public void Delete(UserBorrowsCopy ubc)
        {
            table.Remove(ubc);
        }

        public void DeleteRange(IEnumerable<UserBorrowsCopy> ubcs)
        {
            table.RemoveRange(ubcs);
        }

        public List<UserBorrowsCopy> GetAll()
        {
            return table.ToList();
        }

        public async Task<List<UserBorrowsCopy>> GetAllAsync()
        {
            return await table.ToListAsync();
        }

        public List<UserBorrowsCopy> GetAllByCopyId(Guid copyId)
        {
            return table.Where(x => x.CopyId.Equals(copyId)).ToList();
        }

        public List<UserBorrowsCopy> GetAllByUserId(Guid userId)
        {
            return table.Where(x => x.UserId.Equals(userId)).ToList();
        }

        public List<UserBorrowsCopy> GetAllInvalid()
        {
            var today = DateTime.UtcNow.Date;
            return table.Where(x => x.EndDate.CompareTo(today) < 0).ToList();
        }

        public List<UserBorrowsCopy> GetAllValid()
        {
            var today = DateTime.UtcNow.Date;
            return table.Where(x => x.EndDate.CompareTo(today) >= 0).ToList();
        }

        public bool Save()
        {
            return context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(UserBorrowsCopy ubc)
        {
            table.Update(ubc);
        }

        public void UpdateRange(IEnumerable<UserBorrowsCopy> ubc)
        {
            table.UpdateRange(ubc);
        }
    }
}