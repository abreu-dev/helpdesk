using FluentValidation;
using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.Exceptions;

namespace HelpDesk.Core.Domain.Validations
{
    public abstract class ValidatableEntity : DomainEntity
    {
        private readonly List<CustomValidationResult> _validationResults;
        public IReadOnlyCollection<CustomValidationResult> ValidationResults => _validationResults;

        protected ValidatableEntity()
        {
            _validationResults = new List<CustomValidationResult>();
        }

        public TPropType PassThroughValidation<TPropType>(string propName, TPropType propValue, AbstractValidator<TPropType> propValidator)
        {
            if (ValidationResults.Any(x => x.PropName == propName))
                throw new Exception(string.Format("Prop {0} already went through validation.", propName));

            var result = propValidator.Validate(propValue);
            _validationResults.Add(new CustomValidationResult(propName, propValidator.GetType().Name, result));

            if (result.Errors.Any())
            {
                var firstError = result.Errors.First();
                throw new DetailedException(firstError.ErrorCode, firstError.ErrorMessage, firstError.Severity.ToString());
            }

            return propValue;
        }
    }
}
