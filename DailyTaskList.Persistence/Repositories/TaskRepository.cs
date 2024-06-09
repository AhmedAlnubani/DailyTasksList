using DailyTasksList.Application.Contracts;
using DailyTasksList.Domain.Entities;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace DailyTasksList.Persistence.Repositories
{
#region Public  class
    public class TaskRepository : BaseRepository<DailyTaskes>, ITaskRepository
    {
        #region public  Constructor
        public TaskRepository(ApplicationDbContext _dbContext) : base(_dbContext)
        {

        }
        #endregion public  Constructor
        #region public  Methods
        public async Task<IReadOnlyList<DailyTaskes>> GetAllTaskesAsync(bool includeFinished)
        {
            List<DailyTaskes> allPosts = new List<DailyTaskes>();
            allPosts = includeFinished ? await _dbContext.DailyTaskes.Where(x => x.Status=="Completed").ToListAsync() : await _dbContext.DailyTaskes.ToListAsync();
            return allPosts;
        }

        public async Task<DailyTaskes> GetTaskesByIdAsync(long id, bool includeFinished)
        {
           var task = includeFinished ? await _dbContext.DailyTaskes.Where(x => x.Status=="Completed").FirstOrDefaultAsync(x => x.Id == id) : await _dbContext.DailyTaskes.FirstOrDefaultAsync(x => x.Id == id);
            return (DailyTaskes)task;

        }
        #endregion public  Methods
    }
    #endregion Public  Class
}
