using HelpDesk.Core.Domain.Extensions;

namespace HelpDesk.Core.Domain.Test.Extensions
{
    public class StringExtensionsTest
    {
        [Fact]
        public void Format_ShouldReplaceTemplate()
        {
            // Arrange
            var randomWords = new Faker().Random.WordsArray(4);

            var template1 = "{PropName}";
            var template2 = "{PropName} " + randomWords[0];
            var template3 = randomWords[1] + " {PropName}";
            var template4 = randomWords[2] + " {PropName} " + randomWords[3];

            var parameters = new
            {
                PropName = new Faker().Random.Word()
            };

            // Act
            var formatedTemplate1 = template1.Format(parameters);
            var formatedTemplate2 = template2.Format(parameters);
            var formatedTemplate3 = template3.Format(parameters);
            var formatedTemplate4 = template4.Format(parameters);

            // Assert
            formatedTemplate1.Should().Be(parameters.PropName);
            formatedTemplate2.Should().Be($"{parameters.PropName} {randomWords[0]}");
            formatedTemplate3.Should().Be($"{randomWords[1]} {parameters.PropName}");
            formatedTemplate4.Should().Be($"{randomWords[2]} {parameters.PropName} {randomWords[3]}");
        }
    }
}
