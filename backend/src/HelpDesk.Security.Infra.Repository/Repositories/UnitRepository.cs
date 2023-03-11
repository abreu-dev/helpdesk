using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.Core.Repositories;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Security.Domain.Entities;
using HelpDesk.Security.Domain.Repositories;

namespace HelpDesk.Security.Infra.Repository.Repositories
{
    public class UnitRepository : RepositoryAuditable<UnitDomain, UnitData>, IUnitRepository
    {
        public UnitRepository(IDataContext context) : base(context)
        {
        }

        protected override UnitData ToData(UnitDomain domainEntity)
        {
            return new UnitData
            {
                Id = domainEntity.Id,
                Name = domainEntity.Name,
                Code = domainEntity.Code
            };
        }

        protected override UnitDomain ToDomain(UnitData dataEntity)
        {
            return new UnitDomain
            {
                Id = dataEntity.Id,
                Name = dataEntity.Name,
                Code = dataEntity.Code
            };
        }
    }
}
