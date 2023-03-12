﻿using HelpDesk.WebApi.Scope.Middlewares;

namespace HelpDesk.WebApi.Scope
{
    public static class DependencyResolverService
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<ExceptionMiddleware>();

            FromProjects(services);
        }

        private static void FromProjects(IServiceCollection services)
        {
            Infra.DbContext.DependencyResolverService.Register(services);
            Security.Infra.CrossCutting.IoC.DependencyResolverService.Register(services);
            Ticket.Infra.CrossCutting.IoC.DependencyResolverService.Register(services);
        }
    }
}
