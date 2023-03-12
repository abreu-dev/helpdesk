using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Ticket.Contracts;

namespace HelpDesk.Ticket.Application.Queries.Interfaces
{
    public interface ICategoryAppQuery
    {
        TreeView<CategoryTreeDto> GetTree();
    }
}
