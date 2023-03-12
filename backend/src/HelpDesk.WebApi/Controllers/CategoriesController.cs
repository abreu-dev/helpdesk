using HelpDesk.Security.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAppQuery _categoryAppQuery;

        public CategoriesController(ICategoryAppQuery categoryAppQuery)
        {
            _categoryAppQuery = categoryAppQuery;
        }

        [HttpGet("tree")]
        public IActionResult GetTeste()
        {
            var treeView = _categoryAppQuery.GetTree();
            return Ok(treeView);
        }
    }
}
