using HelpDesk.Domain.Core.Entities;

namespace HelpDesk.Ticket.Domain.Entities
{
    public class CategoryDomain : DomainEntity
    {
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
