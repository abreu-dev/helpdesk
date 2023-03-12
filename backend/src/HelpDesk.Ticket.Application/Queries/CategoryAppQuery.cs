using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Ticket.Application.Queries.Interfaces;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries;

namespace HelpDesk.Ticket.Application.Queries
{
    public class CategoryAppQuery : ICategoryAppQuery
    {
        private readonly ICategoryQuery _categoryQuery;

        public CategoryAppQuery(ICategoryQuery categoryQuery)
        {
            _categoryQuery = categoryQuery;
        }

        public TreeView<CategoryTreeDto> GetTree()
        {
            return _categoryQuery.GetTree();
        }
    }
}
