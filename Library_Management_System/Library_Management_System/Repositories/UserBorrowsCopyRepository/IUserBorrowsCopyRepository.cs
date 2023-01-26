﻿using Library_Management_System.Models;

namespace Library_Management_System.Repositories.UserBorrowsCopyRepository
{
    public interface IUserBorrowsCopyRepository
    {
        // Create
        void Create(UserBorrowsCopy ubc);
        Task CreateAsync(UserBorrowsCopy ubc);
        void CreateRange(IEnumerable<UserBorrowsCopy> ubcs);
        Task CreateRangeAsync(IEnumerable<UserBorrowsCopy> ubcs);

        // Find
        public List<UserBorrowsCopy> GetAll();

        public Task<List<UserBorrowsCopy>> GetAllAsync();

        public List<UserBorrowsCopy> GetAllByUserId(Guid userId);

        public List<UserBorrowsCopy> GetAllByCopyId(Guid copyId);

        public List<UserBorrowsCopy> GetAllValid();

        public List<UserBorrowsCopy> GetAllInvalid();


        // Update
        void Update(UserBorrowsCopy ubc);
        void UpdateRange(IEnumerable<UserBorrowsCopy> ubc);

        // Delete
        void Delete(UserBorrowsCopy ubc);
        void DeleteRange(IEnumerable<UserBorrowsCopy> ubcs);

        // Save
        bool Save();
        Task<bool> SaveAsync();
    }
}