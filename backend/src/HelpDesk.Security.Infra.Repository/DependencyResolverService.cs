using HelpDesk.Security.Domain.Queries;
using HelpDesk.Security.Domain.Repositories;
using HelpDesk.Security.Infra.Repository.Queries;
using HelpDesk.Security.Infra.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Security.Infra.Repository
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            Repositories(services);
            Queries(services);
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IUnitRepository, UnitRepository>();
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<IUnitQuery, UnitQuery>();
            services.AddScoped<ICategoryQuery, CategoryQuery>();
        }
    }
}
