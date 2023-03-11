﻿using HelpDesk.Domain.Core.Data;
using HelpDesk.Domain.Core.Entities;
using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace HelpDesk.Infra.Core.Repositories
{
    public abstract class RepositoryEntity<TDomainEntity, TDataEntity> : IRepositoryEntity<TDomainEntity>
        where TDomainEntity : DomainEntity
        where TDataEntity : DataEntity
    {
        protected readonly IDataContext _context;
        protected readonly DbSet<TDataEntity> _dbSet;

        protected RepositoryEntity(IDataContext context)
        {
            _context = context;
            _dbSet = _context.GetDbSet<TDataEntity>();
        }

        public IList<TDomainEntity> GetAll()
        {
            var dataEntities = _dbSet.AsNoTracking().ToList();
            return dataEntities.Select(ToDomain).ToList();
        }

        public TDomainEntity? GetById(Guid domainEntityId)
        {
            var dataEntity = _dbSet.AsNoTracking().SingleOrDefault(x => x.Id == domainEntityId);

            if (dataEntity == null) return null;

            return ToDomain(dataEntity);
        }

        public bool Exists(Guid domainEntityId)
        {
            return _dbSet.Any(x => x.Id == domainEntityId);
        }

        public void Add(TDomainEntity domainEntity)
        {
            var dataEntity = ToData(domainEntity);
            _context.AddData(dataEntity);
        }

        public void Update(TDomainEntity domainEntity)
        {
            var dataEntity = ToData(domainEntity);
            _context.UpdateData(dataEntity);
        }

        public void Delete(Guid domainEntityId)
        {
            var dataEntity = _dbSet.SingleOrDefault(x => x.Id == domainEntityId);
            if (dataEntity != null) _context.DeleteData(dataEntity);
        }

        public int CommitChanges()
        {
            return _context.CommitChanges();
        }

        public void RollBackChanges()
        {
            _context.RollBackChanges();
        }

        protected abstract TDomainEntity ToDomain(TDataEntity dataEntity);
        protected abstract TDataEntity ToData(TDomainEntity domainEntity);
    }
}
