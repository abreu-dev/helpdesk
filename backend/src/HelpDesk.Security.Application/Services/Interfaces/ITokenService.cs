using HelpDesk.Security.Application.Models;
using HelpDesk.Security.Domain.Entities;

namespace HelpDesk.Security.Application.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateAuthenticationToken(UserDomain user);
        ValidatedToken ValidateToken(string? token);
    }
}
