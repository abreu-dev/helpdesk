using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Security.Application.AppQueries.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;
using HelpDesk.Security.Domain.Queries.Parameters;

namespace HelpDesk.Security.Application.AppQueries
{
    public class UserAppQuery : IUserAppQuery
    {
        private readonly IUserQuery _userQuery;

        public UserAppQuery(IUserQuery userQuery)
        {
            _userQuery = userQuery;
        }

        public UserDto GetById(Guid userId)
        {
            return _userQuery.GetById(userId);
        }

        public IPagedList<UserDto> Paginate(IUserParameters parameters)
        {
            return _userQuery.Paginate(parameters);
        }
    }
}
