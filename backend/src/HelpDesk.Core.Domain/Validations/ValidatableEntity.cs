using FluentValidation;
using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Domain.Extensions;

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
                throw new Exception("Prop {PropName} already went through validation.".Format(new { PropName = propName }));

            var result = propValidator.Validate(propValue);
            _validationResults.Add(new CustomValidationResult(propName, propValidator.GetType().Name, result));

            if (result.Errors.Any())
            {
                var firstError = result.Errors.First();
                var firstErrorCustomState = firstError.CustomState as CustomValidationState;

                if (firstErrorCustomState != null)
                    throw new DetailedException(firstErrorCustomState.Type, firstErrorCustomState.Error, firstErrorCustomState.Detail);

                throw new DetailedException(firstError.ErrorCode, firstError.ErrorMessage, firstError.ErrorMessage);
            }

            return propValue;
        }
    }
}
