using HelpDesk.Core.Domain.Data;
using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Infra.Data.Context;
using HelpDesk.Core.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Core.Infra.Data.Repositories
{
    public abstract class EntityRepository<TDomainEntity, TDataEntity> : IEntityRepository<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TDataEntity : DataEntity
    {
        protected readonly IDataContext _dataContext;
        protected readonly DbSet<TDataEntity> _dbSet;

        protected EntityRepository(IDataContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.GetDbSet<TDataEntity>();
        }

        protected abstract TDomainEntity Convert(TDataEntity dataEntity);
        protected abstract TDataEntity Convert(TDomainEntity domainEntity);

        public virtual IList<TDomainEntity> GetAll()
        {
            var dataEntities = _dbSet.AsNoTracking().ToList();
            return dataEntities.Select(Convert).ToList();
        }

        public virtual TDomainEntity? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking().SingleOrDefault(x => x.Id == domainEntityId);

            if (dataEntity == null) return null;

            return Convert(dataEntity);
        }

        public virtual bool Exists(Guid domainEntityId)
        {
            return _dbSet.Any(x => x.Id == domainEntityId);
        }

        public virtual TDomainEntity Add(TDomainEntity domainEntity)
        {
            var dataEntity = Convert(domainEntity);
            _dbSet.Add(dataEntity);
            return domainEntity;
        }

        public virtual void Update(TDomainEntity domainEntity)
        {
            var dataEntity = Convert(domainEntity);
            _dbSet.Update(dataEntity);
        }

        public virtual void Delete(Guid domainEntityId)
        {
            var dataEntity = _dbSet.SingleOrDefault(x => x.Id == domainEntityId);
            if (dataEntity != null) _dbSet.Remove(dataEntity);
        }

        public int CommitChanges()
        {
            return _dataContext.CommitChanges();
        }

        public void RollBackChanges()
        {
            _dataContext.RollBackChanges();
        }
    }
}
