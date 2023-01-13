using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace HelpDesk.WebApi.Scope.Handlers
{
    public class AuthenticationTokenFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private const string DefaultLanguage = "EN";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (HasFilter(context, typeof(IgnoreAuthenticationTokenFilterAttribute)))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(DefaultLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(DefaultLanguage);
                return;
            };

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                return;
            }

            context.Result = new UnauthorizedObjectResult(null);
        }

        private static bool HasFilter(AuthorizationFilterContext context, Type tokenFilter)
        {
            return context.ActionDescriptor.FilterDescriptors.Any(x => x.Filter.GetType() == tokenFilter);
        }
    }
}
