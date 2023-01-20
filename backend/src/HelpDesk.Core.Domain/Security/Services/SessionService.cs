using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Domain.Security.Interfaces;

namespace HelpDesk.Core.Domain.Security.Services
{
    public class SessionService : ISessionService
    {
        public IAuthenticatedUser? User { get; private set; }

        public Guid UserId => User != null ? User.Id : throw new NotAuthenticatedException();

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
