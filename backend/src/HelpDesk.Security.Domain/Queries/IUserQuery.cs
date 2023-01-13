using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries.Parameters;

namespace HelpDesk.Security.Domain.Queries
{
    public interface IUserQuery
    {
        UserDto GetById(Guid userId);
        IPagedList<UserDto> Paginate(IUserParameters parameters);
    }
}
