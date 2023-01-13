using HelpDesk.Core.Domain.Security.Interfaces;

namespace HelpDesk.Core.Domain.Security.Services
{
    public class SessionService : ISessionService
    {
        public IAuthenticatedUser? User { get; private set; }

        public bool IsAuthenticated()
        {
            return User != null;
        }

        public void Authenticate(IAuthenticatedUser user)
        {
            User = user;
        }
    }
}
