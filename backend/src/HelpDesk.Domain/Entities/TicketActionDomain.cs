namespace HelpDesk.Domain.Entities
{
    public class TicketActionDomain
    {
        public DateTime CreatedOn { get; set; }
        public UserDomain CreatedBy { get; set; }
        public string Message { get; set; }
    }
}
