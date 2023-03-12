using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Ticket.Contracts;

namespace HelpDesk.Ticket.Domain.Queries
{
    public interface ICategoryQuery
    {
        CategoryDto GetById(Guid categoryId);
        TreeView<CategoryTreeDto> GetTreeView();
    }
}
