namespace HelpDesk.Domain.Entities
{
    public class TicketHistoryDomain
    {
        public DateTime CreatedOn { get; set; }
        public UserDomain CreatedBy { get; set; }
        public TicketStatus Status { get; set; }
    }
}
