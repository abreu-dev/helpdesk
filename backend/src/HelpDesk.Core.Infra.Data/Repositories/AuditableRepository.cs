using HelpDesk.Core.Domain.Data;
using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Entities;

namespace HelpDesk.Core.Infra.Data.Repositories
{
    public abstract class AuditableRepository<TDomainEntity, TDataEntity> : EntityRepository<TDomainEntity, TDataEntity>, IEntityRepository<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TDataEntity : AuditableEntity
    {
        protected readonly ISessionService _sessionService;

        protected AuditableRepository(IDataContext dataContext,
                                      ISessionService sessionService) : base(dataContext)
        {
            _sessionService = sessionService;
        }

        public override TDomainEntity Add(TDomainEntity domainEntity)
        {
            var dataEntity = Convert(domainEntity);
            dataEntity.OnCreate(_sessionService.User?.Id ?? Guid.Empty);
            _dbSet.Add(dataEntity);
            return domainEntity;
        }

        public override void Update(TDomainEntity domainEntity)
        {
            var dataEntity = Convert(domainEntity);
            dataEntity.OnUpdate(_sessionService.User?.Id ?? Guid.Empty);
            _dbSet.Update(dataEntity);

            var entry = _dataContext.GetDbEntry(dataEntity);
            if (entry != null)
            {
                entry.Property(x => x.CreatedBy).IsModified = false;
                entry.Property(x => x.CreatedOn).IsModified = false;
            }
        }
    }
}
