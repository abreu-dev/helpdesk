using HelpDesk.Ticket.Application.Services.Interfaces;
using HelpDesk.Ticket.Contracts;
using HelpDesk.Ticket.Domain.Entities;
using HelpDesk.Ticket.Domain.Repositories;

namespace HelpDesk.Ticket.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public CategoryDto Create(CategoryForCreationDto categoryForCreationDto)
        {
            var categoryDomain = new CategoryDomain
            {
                Id = Guid.NewGuid(),
                Name = categoryForCreationDto.Name,
                ParentCategoryId = categoryForCreationDto.ParentCategoryId
            };

            _categoryRepository.Add(categoryDomain);
            _categoryRepository.CommitChanges();

            return new CategoryDto
            {
                Id = categoryDomain.Id,
                Name = categoryDomain.Name,
                ParentCategoryId = categoryDomain.ParentCategoryId
            };
        }
    }
}
