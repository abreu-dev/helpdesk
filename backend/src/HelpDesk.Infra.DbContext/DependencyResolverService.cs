using HelpDesk.Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.Infra.DbContext
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();

            services.AddDbContext<DataContext>(
                options => options.UseSqlServer("name=ConnectionStrings:HelpDesk", x => x.MigrationsAssembly("HelpDesk.Infra.DbMigrations")));
        }
    }
}
