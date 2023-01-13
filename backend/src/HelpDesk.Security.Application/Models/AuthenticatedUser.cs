using HelpDesk.Core.Domain.Security;

namespace HelpDesk.Security.Application.Models
{
    public class AuthenticatedUser : IAuthenticatedUser
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Language { get; set; }
    }
}
