namespace HelpDesk.Core.Domain.Security
{
    public interface IAuthenticatedUser
    {
        Guid Id { get; }
        string Name { get; }
        string Email { get; }
        string Username { get; }
        string Language { get; }
    }
}
