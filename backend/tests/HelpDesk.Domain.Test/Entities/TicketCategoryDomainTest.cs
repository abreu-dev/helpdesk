using FluentAssertions;
using HelpDesk.Core.Domain.ProtectSkills.Skills;
using HelpDesk.Domain.Entities;
using HelpDesk.TestHelpers.Fixtures;

namespace HelpDesk.Domain.Test.Entities
{
    public class TicketCategoryDomainTest
    {
        [Fact]
        public void Ctor_ShouldSetProperties()
        {
            // Arrange
            var description = TicketCategoryFixture.Description;

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
            var id = Guid.NewGuid();
            var description = TicketCategoryFixture.Description;

            // Act
            var ticketCategory = new TicketCategoryDomain(id, description);

            // Assert
            ticketCategory.Id.Should().Be(id);
            ticketCategory.Description.Should().Be(description);
        }

        [Fact]
        public void Ctor_ShouldSetProtectSkills()
        {
            // Arrange & Act
            var ticketCategory = new TicketCategoryDomain(TicketCategoryFixture.Description);

            // Assert
            ticketCategory.ProtectSkills.Should().HaveCount(2);

            ticketCategory.ProtectSkills.Should().ContainSingle(x =>
                x.PropertyName == nameof(TicketCategoryDomain.Id)
                && x.AppliedSkills.Count == 1
                && x.AppliedSkills.Any(y => y.SkillName == ProtectSkillExtensions.EmptySkillName));

            ticketCategory.ProtectSkills.Should().ContainSingle(x =>
                x.PropertyName == nameof(TicketCategoryDomain.Description)
                && x.AppliedSkills.Count == 1
                && x.AppliedSkills.Any(y => y.SkillName == ProtectSkillExtensions.NullOrEmptySkillName));
        }
    }
}
