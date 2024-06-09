using DailyTasksList.Domain.Entities;

namespace DailyTasksList.Application.Contracts
{
    #region Public Interface
    public interface ITaskRepository : IAsyncRepository<DailyTaskes>
    {
        #region Public Method
        //for get task finsh only
        Task<IReadOnlyList<DailyTaskes>> GetAllTaskesAsync(bool includeFinished);
        Task<DailyTaskes> GetTaskesByIdAsync(long id, bool includeFinished);
        #endregion Public Method
    }

    #endregion Public Interface
}
