using HelpDesk.Security.Application.AppQueries.Interfaces;
using HelpDesk.Security.Infra.Repository.Queries.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserAppQuery _userAppQuery;

        public UsersController(IUserAppQuery userAppQuery)
        {
            _userAppQuery = userAppQuery;
        }

        [HttpGet]
        public IActionResult PaginateUsers([FromQuery] UserParameters parameters)
        {
            var usersDto = _userAppQuery.Paginate(parameters);
            return Ok(usersDto);
        }

        [HttpGet("{userId:guid}")]
        public IActionResult GetUserById(Guid userId)
        {
            var userDto = _userAppQuery.GetById(userId);
            return Ok(userDto);
        }
    }
}
