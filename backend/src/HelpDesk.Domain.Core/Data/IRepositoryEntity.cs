using HelpDesk.Domain.Core.Entities;

namespace HelpDesk.Domain.Core.Data
{
    public interface IRepositoryEntity<TDomainEntity> where TDomainEntity : DomainEntity
    {
        IList<TDomainEntity> GetAll();
        TDomainEntity? GetById(Guid domainEntityId);

        bool Exists(Guid domainEntityId);

        void Add(TDomainEntity domainEntity);
        void Update(TDomainEntity domainEntity);
        void Delete(Guid domainEntityId);

        int CommitChanges();
        void RollBackChanges();
    }
}
