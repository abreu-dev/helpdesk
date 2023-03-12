using HelpDesk.Security.Application.Queries;
using HelpDesk.Security.Application.Queries.Interfaces;
using HelpDesk.Security.Application.Services;
using HelpDesk.Security.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Security.Application
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            AppServices(services);
            AppQueries(services);
        }

        public static void AppServices(IServiceCollection services)
        {
            services.AddScoped<IUnitAppService, UnitAppService>();
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<IUnitAppQuery, UnitAppQuery>();
            services.AddScoped<ICategoryAppQuery, CategoryAppQuery>();
        }
    }
}
