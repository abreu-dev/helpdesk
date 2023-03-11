using HelpDesk.Security.Contracts;

namespace HelpDesk.Security.Application.Queries.Interfaces
{
    public interface IUnitAppQuery
    {
        UnitDto GetById(Guid unitId);
    }
}
