using HelpDesk.WebApi.Scope.Handlers;

namespace HelpDesk.WebApi.Scope.Extensions
{
    public static class ControllersServiceCollectionExtensions
    {
        public static void AddCustomControllers(this IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                options.Filters.Add(typeof(AuthenticationTokenFilterAttribute));
            }).AddNewtonsoftJson();
        }
    }
}
