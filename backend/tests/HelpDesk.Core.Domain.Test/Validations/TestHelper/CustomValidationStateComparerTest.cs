using HelpDesk.Core.Domain.Validations;
using HelpDesk.Core.Domain.Validations.TestHelper;

namespace HelpDesk.Core.Domain.Test.Validations.TestHelper
{
    public class CustomValidationStateComparerTest
    {
        private static CustomValidationState FirstCustomValidationState { get; set; }
        private static CustomValidationState SecondCustomValidationState { get; set; }

        public CustomValidationStateComparerTest()
        {
            var type = new Faker().Random.Word();
            var error = new Faker().Random.Word();
            var detail = new Faker().Random.Word();

            FirstCustomValidationState = new CustomValidationState(type, error, detail);
            SecondCustomValidationState = new CustomValidationState(type, error, detail);
        }

        [Fact]
        public void Equals_WhenMatchAllProps_ShouldReturnTrue()
        {
            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void Equals_WhenFirstDontMatchClassType_ShouldReturnFalse()
        {
            // Arrange
            var otherObject = new object();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, otherObject);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenSecondDontMatchClassType_ShouldReturnFalse()
        {
            // Arrange
            var otherObject = new object();

            // Act
            var result = new CustomValidationStateComparer().Equals(otherObject, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenFirstDontMatchType_ShouldReturnFalse()
        {
            // Arrange
            FirstCustomValidationState.Type = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenSecondDontMatchType_ShouldReturnFalse()
        {
            // Arrange
            SecondCustomValidationState.Type = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenFirstDontMatchError_ShouldReturnFalse()
        {
            // Arrange
            FirstCustomValidationState.Error = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenSecondDontMatchError_ShouldReturnFalse()
        {
            // Arrange
            SecondCustomValidationState.Error = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenFirstDontMatchDetail_ShouldReturnFalse()
        {
            // Arrange
            FirstCustomValidationState.Detail = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Equals_WhenSecondDontMatchDetail_ShouldReturnFalse()
        {
            // Arrange
            SecondCustomValidationState.Detail = new Faker().Random.Word();

            // Act
            var result = new CustomValidationStateComparer().Equals(FirstCustomValidationState, SecondCustomValidationState);

            // Assert
            result.Should().BeFalse();
        }
    }
}
