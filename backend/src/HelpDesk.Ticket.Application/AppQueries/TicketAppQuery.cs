using HelpDesk.Core.Domain.Data.Pagination;
using HelpDesk.Ticket.Application.AppQueries.Interfaces;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries;
using HelpDesk.Ticket.Domain.Queries.Parameters;

namespace HelpDesk.Ticket.Application.AppQueries
{
    public class TicketAppQuery : ITicketAppQuery
    {
        private readonly ITicketQuery _ticketQuery;

        public TicketAppQuery(ITicketQuery ticketQuery)
        {
            _ticketQuery = ticketQuery;
        }

        public TicketDto GetById(Guid userId)
        {
            return _ticketQuery.GetById(userId);
        }

        public IPagedList<TicketDto> Paginate(ITicketParameters parameters)
        {
            return _ticketQuery.Paginate(parameters);
        }
    }
}
