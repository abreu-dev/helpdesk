using HelpDesk.Security.Contracts;

namespace HelpDesk.Security.Domain.Queries
{
    public interface IUnitQuery
    {
        UnitDto GetById(Guid unitId);
    }
}
