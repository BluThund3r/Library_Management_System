using Library_Management_System.Data;
using Library_Management_System.Models.BaseEntity;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly ApplicationContext context;
        protected readonly DbSet<TEntity> table;

        public GenericRepository(ApplicationContext context_)
        {
            context = context_;
            table = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await table.AddRangeAsync(entities);
        }

        public void Delete(TEntity entity)
        {
            table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            table.RemoveRange(entities);
        }

        public TEntity FindById(object id)
        {
            return table.Find(id);
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await table.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return table.AsNoTracking();
        }

        public bool Save()
        {
            return context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await context.SaveChangesAsync() > 0;
        }

        public void Update(TEntity entity)
        {
            table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            table.UpdateRange(entities);
        }
    }
}
