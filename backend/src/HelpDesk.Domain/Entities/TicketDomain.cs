namespace HelpDesk.Domain.Entities
{
    public class TicketDomain
    {
        public int Number { get; set; }

        public UserDomain Applicant { get; set; }

        public UserDomain Responsible { get; set; }

        public TicketStatus Status { get; }

        public TicketCategoryDomain Category { get; set; }

        public List<TicketHistoryDomain> History { get; set; }

        public List<TicketActionDomain> Actions { get; set; }
    }
}
