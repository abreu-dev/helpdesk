using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries.Parameters;

namespace HelpDesk.Ticket.Domain.Queries
{
    public interface ITicketQuery
    {
        TicketDto GetById(Guid ticketId);
        IPagedList<TicketDto> Paginate(ITicketParameters parameters);
    }
}
