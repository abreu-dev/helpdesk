using HelpDesk.Core.Domain.Validations;

namespace HelpDesk.Core.Domain.Test.Validations
{
    public class CustomValidationStateTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Arrange
            var type = new Faker().Random.Word();
            var error = new Faker().Random.Word();
            var detail = new Faker().Random.Word();

            // Act
            var customValidationState = new CustomValidationState(type, error, detail);

            // Assert
            customValidationState.Type.Should().Be(type);
            customValidationState.Error.Should().Be(error);
            customValidationState.Detail.Should().Be(detail);
        }
    }
}
