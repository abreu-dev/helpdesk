using HelpDesk.Core.Domain.Exceptions;

namespace HelpDesk.Core.Domain.Test.Exceptions
{
    public class DetailedExceptionTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Arrange
            var type = new Faker().Random.Word();
            var error = new Faker().Random.Word();
            var detail = new Faker().Random.Word();

            // Act
            var detailedException = new DetailedException(type, error, detail);

            // Assert
            detailedException.Type.Should().Be(type);
            detailedException.Error.Should().Be(error);
            detailedException.Detail.Should().Be(detail);
        }
    }
}
