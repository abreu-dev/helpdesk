using HelpDesk.Security.Application.AppQueries;
using HelpDesk.Security.Application.AppQueries.Interfaces;
using HelpDesk.Security.Application.Services;
using HelpDesk.Security.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Security.Application
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            AppQueries(services);
            Services(services);
        }

        public static void AppQueries(IServiceCollection services)
        {
            services.AddScoped<IUserAppQuery, UserAppQuery>();
        }

        public static void Services(IServiceCollection services)
        {
            services.AddScoped<ISignInService, SignInService>();
            services.AddScoped<ISignUpService, SignUpService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
