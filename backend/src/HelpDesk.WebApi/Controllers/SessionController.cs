using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.WebApi.Scope.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [IgnoreAuthenticationTokenFilter]
    [Route("api/session")]
    public class SessionController : ControllerBase
    {
        private readonly ISignInService _signInService;
        private readonly ISignUpService _signUpService;
        private readonly ITokenService _tokenService;

        public SessionController(ISignInService signInService,
                                 ISignUpService signUpService,
                                 ITokenService tokenService)
        {
            _signInService = signInService;
            _signUpService = signUpService;
            _tokenService = tokenService;
        }

        [HttpPost("sign-in")]
        public IActionResult SignIn([FromBody] SignInDto signInDto)
        {
            var result = _signInService.SignIn(signInDto);

            return Ok(new SignInResultDto()
            {
                Token = _tokenService.GenerateAuthenticationToken(result),
                User = new UserDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Username = result.Username,
                    Email = result.Email,
                    Language = result.Language
                }
            });
        }

        [HttpPost("sign-up")]
        public IActionResult SignUp([FromBody] SignUpDto signUpDto)
        {
            var result = _signUpService.SignUp(signUpDto);

            return Ok(new SignInResultDto()
            {
                Token = _tokenService.GenerateAuthenticationToken(result),
                User = new UserDto()
                {
                    Id = result.Id,
                    Name = result.Name,
                    Username = result.Username,
                    Email = result.Email,
                    Language = result.Language
                }
            });
        }
    }
}
