using DailyTasksList.Application.Contracts;
using DailyTasksList.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DailyTasksList.Persistence.Repositories
{
    #region Public  Class
    public class UserRepository : IUserRepository
    {
        #region private  properties
        private readonly ApplicationDbContext _dbContext;
        #endregion private  properties

        #region Private  Constructor
        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #endregion Private  Constructor


        #region Public  Methods
        public async Task<User> GetUserByUserName(string userName)
        {
            var user = await _dbContext.Users.Where(x => x.UserName == userName)
                                .Include(a => a.UserRoles)
                                .ThenInclude(a => a.Role)
                                .FirstOrDefaultAsync();
                return user;

        }
        #endregion Public  Methods
    }
    #endregion Public  Class
}
