using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries.Parameters;

namespace HelpDesk.Security.Application.AppQueries.Interfaces
{
    public interface IUserAppQuery
    {
        IPagedList<UserDto> Paginate(IUserParameters parameters);
        UserDto GetById(Guid userId);
    }
}
