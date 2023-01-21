using FluentValidation.Results;

namespace HelpDesk.Core.Domain.Validations
{
    public class CustomValidationResult
    {
        public string PropName { get; }
        public string PropValidator { get; }
        public ValidationResult ValidationResult { get; }

        public CustomValidationResult(string propName, string propValidator, ValidationResult validationResult)
        {
            PropName = propName;
            PropValidator = propValidator;
            ValidationResult = validationResult;
        }
    }
}
