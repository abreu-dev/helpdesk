using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Entities;
using HelpDesk.Security.Domain.Repositories;

namespace HelpDesk.Security.Application.Services
{
    public class UnitAppService : IUnitAppService
    {
        private readonly IUnitRepository _unitRepository;

        public UnitAppService(IUnitRepository unitRepository)
        {
            _unitRepository = unitRepository;
        }

        public UnitDto Create(UnitForCreationDto unitForCreationDto)
        {
            var unitDomain = new UnitDomain
            {
                Id = Guid.NewGuid(),
                Name = unitForCreationDto.Name,
                Code = unitForCreationDto.Code
            };

            _unitRepository.Add(unitDomain);
            _unitRepository.CommitChanges();

            return new UnitDto
            {
                Id = unitDomain.Id,
                Name = unitDomain.Name,
                Code = unitDomain.Code
            };
        }
    }
}
