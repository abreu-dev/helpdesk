using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Ticket.Contracts;

namespace HelpDesk.Ticket.Domain.Queries
{
    public interface ICategoryQuery
    {
        TreeView<CategoryTreeDto> GetTree();
    }
}
