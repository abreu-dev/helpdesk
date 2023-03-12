using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Queries;

namespace HelpDesk.Ticket.Infra.Repository.Queries
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly IDataContext _context;

        public CategoryQuery(IDataContext context)
        {
            _context = context;
        }

        public CategoryDto GetById(Guid categoryId)
        {
            var categoryData = _context.Query<CategoryData>().SingleOrDefault(x => x.Id == categoryId);

            if (categoryData == null)
                throw new NullReferenceException("Category");

            return new CategoryDto
            {
                Id = categoryData.Id,
                Name = categoryData.Name,
                ParentCategoryId = categoryData.ParentCategoryId
            };
        }

        public TreeView<CategoryTreeDto> GetTreeView()
        {
            var values = _context.Query<CategoryData>()
                .Select(x => new CategoryTreeDto(x.Id, x.ParentCategoryId, x.Name))
                .ToList();

            var treeView = new TreeView<CategoryTreeDto>(values);

            return treeView;
        }
    }
}
