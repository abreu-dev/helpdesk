using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Core.Domain.Security.Services;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Core.Domain
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            Services(services);
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
        }
    }
}
