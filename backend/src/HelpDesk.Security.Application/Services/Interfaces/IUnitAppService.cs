using HelpDesk.Security.Contracts;

namespace HelpDesk.Security.Application.Services.Interfaces
{
    public interface IUnitAppService
    {
        UnitDto Create(UnitForCreationDto unitForCreationDto);
    }
}
