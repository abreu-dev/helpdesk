namespace HelpDesk.Core.Domain.Security.Interfaces
{
    public interface ISessionService
    {
        IAuthenticatedUser? User { get; }

        bool IsAuthenticated();

        void Authenticate(IAuthenticatedUser user);
    }
}
