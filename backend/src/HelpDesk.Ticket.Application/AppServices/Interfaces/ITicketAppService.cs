using HelpDesk.Ticket.Contracts;

namespace HelpDesk.Ticket.Application.AppServices.Interfaces
{
    public interface ITicketAppService
    {
        TicketDto Create(TicketForCreationDto ticketForCreationDto);
    }
}
