using HelpDesk.Ticket.Domain.Queries;
using HelpDesk.Ticket.Domain.Repositories;
using HelpDesk.Ticket.Infra.Repository.Queries;
using HelpDesk.Ticket.Infra.Repository.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Infra.Repository
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
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<ICategoryQuery, CategoryQuery>();
        }
    }
}
