using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace DailyTasksList.Application.Services
{
    #region Public Class
    public static class ApplicationContainer
    {
        #region Public Properties
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
        #endregion Public Properties
        
    }

    #endregion Public Properties
}
