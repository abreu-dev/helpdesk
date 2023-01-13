using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Repositories;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Infra.Globalization;
using HelpDesk.Security.Domain.Entities;
using HelpDesk.Security.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Security.Infra.Repository.Repositories
{
    public class UserRepository : AuditableRepository<UserDomain, UserData>, IUserRepository
    {
        public UserRepository(IDataContext dataContext,
                              ISessionService sessionService)
            : base(dataContext, sessionService) { }

        public bool AnyWithEmail(string email)
        {
            return _dbSet.Any(x => x.Email == email);
        }

        public bool AnyWithUsername(string username)
        {
            return _dbSet.Any(x => x.Username == username);
        }

        public UserDomain? Authenticate(string username, string password)
        {
            var dataEntity = _dbSet.AsNoTracking().SingleOrDefault(x => x.Username == username && x.Password == password);

            if (dataEntity == null) return null;

            return Convert(dataEntity);
        }

        protected override UserDomain Convert(UserData dataEntity)
        {
            return new UserDomain(
                       dataEntity.Id,
                       dataEntity.Name,
                       dataEntity.Email,
                       dataEntity.Username,
                       dataEntity.Password,
                       dataEntity.Language.GetEnumDisplayDescription());
        }

        protected override UserData Convert(UserDomain domainEntity)
        {
            return new UserData
            {
                Id = domainEntity.Id,
                Name = domainEntity.Name,
                Email = domainEntity.Email,
                Username = domainEntity.Username,
                Password = domainEntity.Password,
                Language = EnumExtensions.GetEnumFromDescription<Language>(domainEntity.Language)
            };
        }
    }
}
