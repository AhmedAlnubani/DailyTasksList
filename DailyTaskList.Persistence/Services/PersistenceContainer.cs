using DailyTasksList.Application.Contracts;
using DailyTasksList.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DailyTasksList.Persistence.Services
{
    #region Public  Class
    public static class PersistenceContainer
    {
        #region Public  Methods
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ITaskRepository), typeof(TaskRepository));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
           
                return services;
        }
        #endregion Public  Methods
    }

    #endregion Public  Class
}
