using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Security.Contracts;

namespace HelpDesk.Security.Domain.Queries
{
    public interface ICategoryQuery
    {
        TreeView<CategoryTreeDto> GetTree();
    }
}
