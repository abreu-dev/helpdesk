using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Entities;

namespace HelpDesk.Security.Application.Services.Interfaces
{
    public interface ISignInService
    {
        UserDomain SignIn(SignInDto signInDto);
    }
}
