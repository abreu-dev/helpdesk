using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries.Parameters;

namespace HelpDesk.Ticket.Application.AppQueries.Interfaces
{
    public interface ITicketAppQuery
    {
        IPagedList<TicketDto> Paginate(ITicketParameters parameters);
        TicketDto GetById(Guid userId);
    }
}
