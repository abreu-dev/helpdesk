using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Pagination;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;
using HelpDesk.Security.Domain.Queries.Parameters;

namespace HelpDesk.Security.Infra.Repository.Queries
{
    public class UserQuery : IUserQuery
    {
        private readonly IDataContext _dataContext;

        public UserQuery(IDataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public UserDto GetById(Guid userId)
        {
            var user = _dataContext.Query<UserData>().SingleOrDefault(x => x.Id == userId);

            if (user == null)
                throw new PropertyNotFoundException(nameof(userId), userId.ToString());

            return new UserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Username = user.Username,
                Language = user.Language.GetEnumDisplayDescription()
            };
        }

        public IPagedList<UserDto> Paginate(IUserParameters parameters)
        {
            var source = _dataContext.Query<UserData>();

            var totalItems = source.Count();

            source = source.OrderBy(p => p.Name);

            var dtos = (from user in source
                        select new UserDto()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Email = user.Email,
                            Username = user.Username,
                            Language = user.Language.GetEnumDisplayDescription()
                        })
                        .Skip(parameters.Page * parameters.Size)
                        .Take(parameters.Size)
                        .ToList();

            return new PagedList<UserDto>(dtos, totalItems, parameters.Page, parameters.Size);
        }
    }
}
