using FluentValidation.TestHelper;
using HelpDesk.Domain.Entities;

namespace HelpDesk.Domain.Test.Entities
{
    public class TicketCategoryDomainTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Arrange
            var description = new Faker().Random.Words();

            // Act
            var ticketCategory = new TicketCategoryDomain(description);

            // Assert
            ticketCategory.Id.Should().NotBeEmpty();
            ticketCategory.Description.Should().Be(description);
        }

        [Fact]
        public void Ctor_WithId_ShouldSetProperties()
        {
            // Arrange
            var id = new Faker().Random.Guid();
            var description = new Faker().Random.Words();

            // Act
            var ticketCategory = new TicketCategoryDomain(id, description);

            // Assert
            ticketCategory.Id.Should().Be(id);
            ticketCategory.Description.Should().Be(description);
        }

        [Fact]
        public void Props_ShouldSetValidators()
        {
            // Arrange & Act
            var ticketCategory = new TicketCategoryDomain(new Faker().Random.Words());

            // Assert
            ticketCategory.ValidationResults.Should().HaveCount(1);
            ticketCategory.ValidationResults.Should().ContainSingle(x => x.PropName == nameof(TicketCategoryDomain.Description) 
                                                                      && x.PropValidator == nameof(TicketCategoryDomain.DescriptionValidator));
        }

        [Fact]
        public void DescriptionValidator_WhenValid_ShouldBeValid()
        {
            // Arrange
            var description = new Faker().Random.Words();
            var validator = new TicketCategoryDomain.DescriptionValidator();

            // Act
            var result = validator.TestValidate(description);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Fact]
        public void DescriptionValidator_WhenEmpty_ShouldNotBeValid()
        {
            // Arrange
            var description = new Faker().Random.String(0);
            var validator = new TicketCategoryDomain.DescriptionValidator();

            // Act
            var result = validator.TestValidate(description);

            // Assert
            result.ShouldHaveValidationErrorFor(nameof(TicketCategoryDomain.Description))
                .WithErrorCode("NotEmptyValidator")
                .Only();
        }
    }
}
