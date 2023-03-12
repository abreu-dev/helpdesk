using HelpDesk.Infra.Core.Context;
using HelpDesk.Infra.Core.Repositories;
using HelpDesk.Infra.DbEntities;
using HelpDesk.Ticket.Domain.Entities;
using HelpDesk.Ticket.Domain.Repositories;

namespace HelpDesk.Ticket.Infra.Repository.Repositories
{
    public class CategoryRepository : RepositoryAuditable<CategoryDomain, CategoryData>, ICategoryRepository
    {
        public CategoryRepository(IDataContext context) : base(context)
        {
        }

        protected override CategoryData ToData(CategoryDomain domainEntity)
        {
            return new CategoryData
            {
                Id = domainEntity.Id,
                Name = domainEntity.Name,
                ParentCategoryId = domainEntity.ParentCategoryId
            };
        }

        protected override CategoryDomain ToDomain(CategoryData dataEntity)
        {
            return new CategoryDomain
            {
                Id = dataEntity.Id,
                Name = dataEntity.Name,
                ParentCategoryId = dataEntity.ParentCategoryId
            };
        }
    }
}
