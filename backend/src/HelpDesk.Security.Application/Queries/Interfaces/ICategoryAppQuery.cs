using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Security.Contracts;

namespace HelpDesk.Security.Application.Queries.Interfaces
{
    public interface ICategoryAppQuery
    {
        TreeView<CategoryTreeDto> GetTree();
    }
}
