using DailyTasksList.Application.Contracts;
using Microsoft.EntityFrameworkCore;


namespace DailyTasksList.Persistence.Repositories
{
    #region Public Class
    public class BaseRepository <T>: IAsyncRepository<T> where T : class
    {
        #region protected Fields
        protected readonly ApplicationDbContext _dbContext;
        #endregion protected Fields


        #region public Constructors
        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion public Constructors

        #region public Method
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
           
        }

        public virtual async Task<T> GetByIdAsync(long id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        #endregion public Method



    }
    #endregion Public Class
}
