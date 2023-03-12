using HelpDesk.Ticket.Application.Queries.Interfaces;
using HelpDesk.Ticket.Application.Services.Interfaces;
using HelpDesk.Ticket.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppQuery _categoryAppQuery;
        private readonly ICategoryAppService _categoryAppService;

        public CategoriesController(ICategoryAppQuery categoryAppQuery, 
                                    ICategoryAppService categoryAppService)
        {
            _categoryAppQuery = categoryAppQuery;
            _categoryAppService = categoryAppService;
        }

        [HttpGet("treeview")]
        public IActionResult TreeView()
        {
            var treeView = _categoryAppQuery.GetTreeView();
            return Ok(treeView);
        }

        [HttpGet("{categoryId:guid}")]
        public IActionResult GetById(Guid categoryId)
        {
            var unitDto = _categoryAppQuery.GetById(categoryId);
            return Ok(unitDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CategoryForCreationDto categoryForCreationDto)
        {
            var categoryDto = _categoryAppService.Create(categoryForCreationDto);
            return CreatedAtAction(nameof(GetById), new { categoryId = categoryDto.Id }, categoryDto);
        }
    }
}
