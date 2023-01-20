using HelpDesk.Core.Domain.Data;
using HelpDesk.Ticket.Domain.Entities;

namespace HelpDesk.Ticket.Domain.Repositories
{
    public interface ITicketRepository : IEntityRepository<TicketDomain>
    {
    }
}
