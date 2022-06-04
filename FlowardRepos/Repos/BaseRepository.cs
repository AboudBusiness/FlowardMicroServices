using Microsoft.EntityFrameworkCore;

namespace FlowardRepos.Repos
{
    public class IBaseRepository<TEntity> : IBaseRepoitory<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entity;

        public IBaseRepository(DbContext context)
        {
            _dbContext = context;
            _entity = context.Set<TEntity>();
        }

        #region CRUD Operations (Async)
        public async Task<List<TEntity>> GetAllAsync() => await _entity.ToListAsync();
        public async Task<TEntity?> GetByIDAsync(int id) => await _entity.FindAsync(id);
        
        public async Task<int> InsertAsync(TEntity entity)
        {
            await _entity.AddAsync(entity);
            
            return await _dbContext.SaveChangesAsync();
        }
        
        public async Task<int> UpdateAsync(TEntity entity)
        {
            _entity.Update(entity);

            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            _entity.Remove(entity);

            return await _dbContext.SaveChangesAsync();
        }
        #endregion
    }
}
