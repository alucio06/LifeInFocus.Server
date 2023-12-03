using LifeInFocus.Business.Interfaces;
using LifeInFocus.Business.Interfaces.Repositories;
using LifeInFocus.Business.Interfaces.Services;
using LifeInFocus.Business.Notificacoes;
using LifeInFocus.Data.Context;
using LifeInFocus.Data.Repositories;

namespace LifeInFocus.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Data
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<IGoalRepository, GoalRepository>();

            // Business
            services.AddScoped<IGoalService, IGoalService>();
            services.AddScoped<INotifier, Notifier>();

            return services;
        }
    }
}
