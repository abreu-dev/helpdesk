using HelpDesk.Ticket.Application.Queries;
using HelpDesk.Ticket.Application.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Application
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            AppQueries(services);
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<ICategoryAppQuery, CategoryAppQuery>();
        }
    }
}
