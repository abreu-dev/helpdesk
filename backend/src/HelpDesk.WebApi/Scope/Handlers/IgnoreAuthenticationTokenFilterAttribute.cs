using Microsoft.AspNetCore.Mvc.Filters;

namespace HelpDesk.WebApi.Scope.Handlers
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class IgnoreAuthenticationTokenFilterAttribute : ActionFilterAttribute { }
}
