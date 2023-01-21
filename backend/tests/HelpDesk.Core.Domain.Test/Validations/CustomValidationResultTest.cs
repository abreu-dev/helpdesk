using Bogus;
using FluentAssertions;
using HelpDesk.Core.Domain.Validations;

namespace HelpDesk.Core.Domain.Test.Validations
{
    public class CustomValidationResultTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Arrange
            var propName = new Faker().Random.Word();
            var propValidator = new Faker().Random.Word();
            var validationResult = new FluentValidation.Results.ValidationResult();

            // Act
            var customValidationResult = new CustomValidationResult(propName, propValidator, validationResult);

            // Assert
            customValidationResult.PropName.Should().Be(propName);
            customValidationResult.PropValidator.Should().Be(propValidator);
            customValidationResult.ValidationResult.Should().Be(validationResult);
        }
    }
}
