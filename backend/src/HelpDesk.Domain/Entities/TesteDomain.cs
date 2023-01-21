using FluentValidation;
using FluentValidation.Results;

namespace HelpDesk.Domain.Entities
{
    public abstract class ValidatableDomain
    {
        public ValidationResult ValidationResult { get; set; }

        public TPropType PassThroughValidation<TPropType>(TPropType value, AbstractValidator<TPropType> validator)
        {
            var result = validator.Validate(value);
            ValidationResult.Errors.AddRange(result.Errors);
            return value;
        }
    }

    public class TesteDomain : ValidatableDomain
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = PassThroughValidation(value, new IdValidator());
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            private set
            {
                _description = PassThroughValidation(value, new DescriptionValidator());
            }
        }

        internal class IdValidator : AbstractValidator<Guid>
        {
            public IdValidator()
            {
                RuleFor(prop => prop)
                    .NotEmpty();
            }
        }

        internal class DescriptionValidator : AbstractValidator<string>
        {
            public DescriptionValidator()
            {
                RuleFor(prop => prop)
                    .NotEmpty();
            }
        }
    }
}
