using HelpDesk.Ticket.Domain.Queries;
using HelpDesk.Ticket.Infra.Repository.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Infra.Repository
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            Queries(services);
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<ICategoryQuery, CategoryQuery>();
        }
    }
}
