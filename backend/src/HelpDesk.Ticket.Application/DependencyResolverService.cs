using HelpDesk.Ticket.Application.AppQueries;
using HelpDesk.Ticket.Application.AppQueries.Interfaces;
using HelpDesk.Ticket.Application.AppServices;
using HelpDesk.Ticket.Application.AppServices.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Application
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            AppQueries(services);
            AppServices(services);
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<ITicketAppQuery, TicketAppQuery>();
        }

        public static void AppServices(IServiceCollection services)
        {
            services.AddScoped<ITicketAppService, TicketAppService>();
        }
    }
}
