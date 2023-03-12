using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Ticket.Infra.CrossCutting.IoC
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            Application.DependencyResolverService.Register(services);
            Repository.DependencyResolverService.Register(services);
        }
    }
}
