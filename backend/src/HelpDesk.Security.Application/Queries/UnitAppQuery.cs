using HelpDesk.Security.Application.Queries.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;

namespace HelpDesk.Security.Application.Queries
{
    public class UnitAppQuery : IUnitAppQuery
    {
        private readonly IUnitQuery _unitQuery;

        public UnitAppQuery(IUnitQuery unitQuery)
        {
            _unitQuery = unitQuery;
        }

        public UnitDto GetById(Guid unitId)
        {
            return _unitQuery.GetById(unitId);
        }
    }
}
