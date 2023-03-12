﻿using HelpDesk.Domain.Core.TreeMaker;
using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Security.Contracts;
using HelpDesk.Security.Domain.Queries;

namespace HelpDesk.Security.Infra.Repository.Queries
{
    public class CategoryQuery : ICategoryQuery
    {
        private readonly IDataContext _context;

        public CategoryQuery(IDataContext context)
        {
            _context = context;
        }

        public TreeView<CategoryTreeDto> GetTree()
        {
            var values = _context.Query<CategoryData>()
                .Select(x => new CategoryTreeDto(x.Id, x.ParentCategoryId, x.Name))
                .ToList();

            var treeView = new TreeView<CategoryTreeDto>(values);

            return treeView;
        }
    }
}
