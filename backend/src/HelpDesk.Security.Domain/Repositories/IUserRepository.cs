using HelpDesk.Core.Domain.Data;
using HelpDesk.Security.Domain.Entities;

namespace HelpDesk.Security.Domain.Repositories
{
    public interface IUserRepository : IEntityRepository<UserDomain>
    {
        bool AnyWithEmail(string email);
        bool AnyWithUsername(string username);

        UserDomain? Authenticate(string username, string password);
    }
}
