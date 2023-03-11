using HelpDesk.Security.Application.Queries.Interfaces;
using HelpDesk.Security.Application.Services.Interfaces;
using HelpDesk.Security.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("api/units")]
    public class UnitsController : ControllerBase
    {
        private readonly IUnitAppService _unitAppService;
        private readonly IUnitAppQuery _unitAppQuery;

        public UnitsController(IUnitAppService unitAppService, 
                               IUnitAppQuery unitAppQuery)
        {
            _unitAppService = unitAppService;
            _unitAppQuery = unitAppQuery;
        }

        [HttpGet("{unitId:guid}")]
        public IActionResult GetById(Guid unitId)
        {
            var unitDto = _unitAppQuery.GetById(unitId);
            return Ok(unitDto);
        }


        [HttpPost]
        public IActionResult Create([FromBody] UnitForCreationDto unitForCreationDto)
        {
            var unitDto = _unitAppService.Create(unitForCreationDto);
            return CreatedAtAction(nameof(GetById), new { unitId = unitDto.Id }, unitDto);
        }
    }
}
