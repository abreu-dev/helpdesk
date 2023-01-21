using FluentValidation;
using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.ProtectSkills.Skills;

namespace HelpDesk.Domain.Entities
{
    public class TicketCategoryDomain : ProtectedDomainEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = CreateProtection(nameof(Id), value)
                    .Against
                    .Empty()
                    .PropertyValue;
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            private set
            {
                _description = CreateProtection(nameof(Description), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        public TicketCategoryDomain(Guid id, string description)
        {
            Id = id;
            Description = description;
        }

        public TicketCategoryDomain(string description) : this(Guid.NewGuid(), description)
        {
        }
    }
}
