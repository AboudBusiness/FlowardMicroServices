using FlowardRepos.Repos;
using FlowardServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlowardServices.Implementations
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepoitory<TEntity> _repository;

        public BaseService(IBaseRepoitory<TEntity> repository) => _repository = repository;

        #region CRUD Operation (Async)
        public async Task<int> DeleteAsync(TEntity entity) => await _repository.DeleteAsync(entity);

        public async Task<List<TEntity>> GetAllAsync() => await _repository.GetAllAsync();

        public async Task<TEntity?> GetByIdAsync(int id) => await _repository.GetByIDAsync(id);

        public async Task<int> InsertAsync(TEntity entity) => await _repository.InsertAsync(entity);

        public async Task<int> UpdateAsync(TEntity entity) => await _repository.UpdateAsync(entity);
        #endregion
    }
}
