using HelpDesk.Ticket.Application.AppQueries.Interfaces;
using HelpDesk.Ticket.Application.AppServices.Interfaces;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Infra.Repository.Queries.Parameters;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.WebApi.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketAppQuery _ticketAppQuery;
        private readonly ITicketAppService _ticketAppService;

        public TicketsController(ITicketAppQuery ticketAppQuery,
                                 ITicketAppService ticketAppService)
        {
            _ticketAppQuery = ticketAppQuery;
            _ticketAppService = ticketAppService;
        }

        [HttpGet]
        public IActionResult PaginateTickets([FromQuery] TicketParameters parameters)
        {
            var ticketsDto = _ticketAppQuery.Paginate(parameters);
            return Ok(ticketsDto);
        }

        [HttpGet("{ticketId:guid}")]
        public IActionResult GetTicketById(Guid ticketId)
        {
            var ticketDto = _ticketAppQuery.GetById(ticketId);
            return Ok(ticketDto);
        }

        [HttpPost]
        public IActionResult CreateTicket([FromBody] TicketForCreationDto ticketForCreationDto)
        {
            var ticketDto = _ticketAppService.Create(ticketForCreationDto);
            return CreatedAtAction(nameof(GetTicketById), new { ticketId = ticketDto.Id }, null);
        }
    }
}
