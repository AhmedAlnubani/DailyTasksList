

namespace DailyTasksList.Application.Contracts
{
    #region Public Interface
    public interface  IAsyncRepository<T> where T :class
    {
        #region Public Mehthod
        Task<T> GetByIdAsync(long id);
         Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

        #endregion Public Mehthod
    }
    #endregion Public Interface
}
