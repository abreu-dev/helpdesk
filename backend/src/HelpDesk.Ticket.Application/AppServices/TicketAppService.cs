using HelpDesk.Core.Domain.Security.Interfaces;
using HelpDesk.Ticket.Application.AppServices.Interfaces;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Entities;
using HelpDesk.Ticket.Domain.Repositories;

namespace HelpDesk.Ticket.Application.AppServices
{
    public class TicketAppService : ITicketAppService
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly ISessionService _sessionService;

        public TicketAppService(ITicketRepository ticketRepository,
                                ISessionService sessionService)
        {
            _ticketRepository = ticketRepository;
            _sessionService = sessionService;
        }

        public TicketDto Create(TicketForCreationDto ticketForCreationDto)
        {
            var customerId = _sessionService.UserId;
            var attendantId = Guid.Parse("40a43fec-ff4e-45aa-a01f-41d21d75cf3b");

            var ticket = new TicketDomain(
                customerId,
                attendantId,
                ticketForCreationDto.Title);

            ticket.AddMessage(customerId, ticketForCreationDto.Message);

            ticket = _ticketRepository.Add(ticket);
            _ticketRepository.CommitChanges();

            return new TicketDto()
            {
                Id = ticket.Id
            };
        }
    }
}
