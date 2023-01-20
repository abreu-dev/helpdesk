namespace HelpDesk.Ticket.Contracts
{
    public class TicketMessageDto
    {
        public string Message { get; set; }
        public TicketMessageOwnerDto Owner { get; set; }
    }
}
