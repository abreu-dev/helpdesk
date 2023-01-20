namespace HelpDesk.Core.Domain.Security.Interfaces
{
    public interface ISessionService
    {
        IAuthenticatedUser? User { get; }
        Guid UserId { get; }

        bool IsAuthenticated();

        void Authenticate(IAuthenticatedUser user);
    }
}
