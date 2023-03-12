using HelpDesk.Ticket.Application.Queries;
using HelpDesk.Ticket.Application.Queries.Interfaces;
using HelpDesk.Ticket.Application.Services;
using HelpDesk.Ticket.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Application
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
            services.AddScoped<ICategoryAppService, CategoryAppService>();
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<ICategoryAppQuery, CategoryAppQuery>();
        }
    }
}
