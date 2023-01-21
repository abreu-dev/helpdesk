﻿using FluentValidation;
using HelpDesk.Core.Domain.Validations;

namespace HelpDesk.Domain.Entities
{
    public class TicketCategoryDomain : ValidatableEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            private set
            {
                _description = PassThroughValidation(nameof(Description), value, new DescriptionValidator());
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

        public class DescriptionValidator : AbstractValidator<string>
        {
            public DescriptionValidator()
            {
                RuleFor(prop => prop)
                    .NotEmpty()
                    .WithName(nameof(Description));
            }
        }
    }
}
