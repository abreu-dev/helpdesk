using Bogus;

namespace HelpDesk.TestHelpers.Fixtures
{
    public class TicketCategoryFixture
    {
        public static string Description => new Faker().Lorem.Word();
    }
}
