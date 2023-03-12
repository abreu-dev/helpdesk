using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Security.Application.Queries.Interfaces;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;

namespace HelpDesk.Security.Application.Queries
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
