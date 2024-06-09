using DailyTasksList.Domain.Entities;

namespace DailyTasksList.Application.Contracts
{
    #region Public Interface
    public  interface IUserRepository  
    {
        #region Public Method
        Task<User> GetUserByUserName(string userName);
        #endregion Public Method
    }
    #endregion Public Interface
}
