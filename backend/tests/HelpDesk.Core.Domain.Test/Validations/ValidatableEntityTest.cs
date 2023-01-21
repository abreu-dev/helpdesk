using FluentValidation;
using HelpDesk.Core.Domain.Exceptions;
using HelpDesk.Core.Domain.Extensions;
using HelpDesk.Core.Domain.Validations;

namespace HelpDesk.Core.Domain.Test.Validations
{
    public class ValidatableEntityTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Act
            var validatableEntity = new ConcreteValidatableEntity();

            // Assert
            validatableEntity.ValidationResults.Should().BeEmpty();
        }

        [Fact]
        public void PassThroughValidation_WhenHaveExistingValidationResultForProp_ShouldThrowException()
        {
            // Arrange
            var validatableEntity = new ConcreteValidatableEntity();

            var propName = new Faker().Random.Word();
            var propValue = new object();
            var propValidator = new ConcreteSucceedAbstractValidator();

            validatableEntity.PassThroughValidation(propName, propValue, propValidator);

            // Act
            var exception = Record.Exception(() => validatableEntity.PassThroughValidation(propName, propValue, propValidator));

            // Assert
            exception.Should().NotBeNull();
            exception.Message.Should().Be("Prop {PropName} already went through validation.".Format(new { PropName = propName }));
        }

        [Fact]
        public void PassThroughValidation_WhenSucceedValidation_ShouldAddCustomValidationResult()
        {
            // Arrange
            var validatableEntity = new ConcreteValidatableEntity();

            var propName = new Faker().Random.Word();
            var propValue = new object();
            var propValidator = new ConcreteSucceedAbstractValidator();

            // Act
            var propResult = validatableEntity.PassThroughValidation(propName, propValue, propValidator);

            // Assert
            propResult.Should().Be(propValue);
            validatableEntity.ValidationResults.Should().HaveCount(1);
            validatableEntity.ValidationResults.Should().ContainSingle(x => x.PropName == propName
                                                                         && x.PropValidator == nameof(ConcreteSucceedAbstractValidator)
                                                                         && x.ValidationResult != null);
        }

        [Fact]
        public void PassThroughValidation_WhenFailValidation_ShouldThrowException()
        {
            // Arrange
            var validatableEntity = new ConcreteValidatableEntity();

            var propName = new Faker().Random.Word();
            var propValue = new object();
            var propValidator = new ConcreteFailAbstractValidator();

            var expectedResult = propValidator.Validate(propValue);

            // Act
            var exception = Record.Exception(() => validatableEntity.PassThroughValidation(propName, propValue, propValidator));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<DetailedException>();

            var detailedException = exception as DetailedException;
            if (detailedException == null) throw new ArgumentException(nameof(detailedException));

            detailedException.Type.Should().Be(expectedResult.Errors.First().ErrorCode);
            detailedException.Error.Should().Be(expectedResult.Errors.First().ErrorMessage);
            detailedException.Detail.Should().Be(expectedResult.Errors.First().ErrorMessage);
        }

        [Fact]
        public void PassThroughValidation_WhenFailValidationWithCustomState_ShouldThrowException()
        {
            // Arrange
            var validatableEntity = new ConcreteValidatableEntity();

            var propName = new Faker().Random.Word();
            var propValue = new object();
            var propValidator = new ConcreteFailWithCustomStateAbstractValidator();

            var expectedResult = propValidator.Validate(propValue);

            // Act
            var exception = Record.Exception(() => validatableEntity.PassThroughValidation(propName, propValue, propValidator));

            // Assert
            exception.Should().NotBeNull();
            exception.Should().BeOfType<DetailedException>();

            var detailedException = exception as DetailedException;
            if (detailedException == null) throw new ArgumentException(nameof(detailedException));

            detailedException.Type.Should().Be("Type");
            detailedException.Error.Should().Be("Error");
            detailedException.Detail.Should().Be("Detail");
        }

        internal class ConcreteValidatableEntity : ValidatableEntity
        {
        }

        internal class ConcreteSucceedAbstractValidator : AbstractValidator<object>
        {
            public ConcreteSucceedAbstractValidator()
            {
                RuleFor(x => x)
                    .Must(y => true);
            }
        }

        internal class ConcreteFailAbstractValidator : AbstractValidator<object>
        {
            public ConcreteFailAbstractValidator()
            {
                RuleFor(x => x)
                    .Must(y => false);
            }
        }

        internal class ConcreteFailWithCustomStateAbstractValidator : AbstractValidator<object>
        {
            public ConcreteFailWithCustomStateAbstractValidator()
            {
                RuleFor(x => x)
                    .Must(y => false)
                    .WithState(x => new CustomValidationState("Type", "Error", "Detail"));
            }
        }
    }
}
