namespace FlowardServices.Interfaces
{
    public interface IBaseService<TEntity>
    {
        #region CRUD Operation (Async)
        /// <summary>
        /// Get all records of provided entity asynchronously
        /// </summary>
        /// <returns>return list of provided entity</returns>
        Task<List<TEntity>> GetAllAsync();

        /// <summary>
        /// Get matched record of provided id asynchronously
        /// </summary>
        /// <param name="id"></param>
        /// <returns>return instance of matched id of entity - if found OR can be return as null - if no found</returns>
        Task<TEntity?> GetByIdAsync(int id);

        /// <summary>
        /// Insert the provided entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>return 1 if entity inserted successfully and 0 if not</returns>
        Task<int> InsertAsync(TEntity entity);

        /// <summary>
        /// Update the provided entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>return 1 if entity updated successfully and 0 if not</returns>
        Task<int> UpdateAsync(TEntity entity);

        /// <summary>
        /// Delete the provided entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>return 1 if entity deleted successfully and 0 if not</returns>
        Task<int> DeleteAsync(TEntity entity);
        #endregion
    }
}