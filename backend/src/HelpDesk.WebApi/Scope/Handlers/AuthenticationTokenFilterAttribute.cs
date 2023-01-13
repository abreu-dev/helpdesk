using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Security.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Globalization;

namespace HelpDesk.WebApi.Scope.Handlers
{
    public class AuthenticationTokenFilterAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private const string DefaultLanguage = "EN";

        private readonly ITokenService _tokenService;
        private readonly ISessionService _userService;

        public AuthenticationTokenFilterAttribute(ITokenService tokenService,
                                                  ISessionService userService)
        {
            _tokenService = tokenService;
            _userService = userService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (HasFilter(context, typeof(IgnoreAuthenticationTokenFilterAttribute)))
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo(DefaultLanguage);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(DefaultLanguage);
                return;
            };

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            var tokenData = _tokenService.ValidateToken(token);

            if (tokenData.IsValid)
            {
                _userService.Authenticate(tokenData.User);

                Thread.CurrentThread.CurrentCulture = new CultureInfo(tokenData.User.Language);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(tokenData.User.Language);

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
