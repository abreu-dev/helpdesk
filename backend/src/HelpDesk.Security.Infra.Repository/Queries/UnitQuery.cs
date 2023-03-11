using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;

namespace HelpDesk.Security.Infra.Repository.Queries
{
    public class UnitQuery : IUnitQuery
    {
        private readonly IDataContext _context;

        public UnitQuery(IDataContext context)
        {
            _context = context;
        }

        public UnitDto GetById(Guid unitId)
        {
            var unitData = _context.Query<UnitData>().SingleOrDefault(x => x.Id == unitId);

            if (unitData == null)
                throw new NullReferenceException("Unit");

            return new UnitDto
            {
                Id = unitData.Id,
                Name = unitData.Name,
                Code = unitData.Code
            };
        }
    }
}
