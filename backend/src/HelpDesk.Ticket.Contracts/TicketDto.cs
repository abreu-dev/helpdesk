namespace HelpDesk.Ticket.Contracts
{
    public class TicketDto
    {
        public Guid Id { get; set; }

        public TicketCustomerDto Customer { get; set; }

        public TicketAttendantDto Attendant { get; set; }

        public string Title { get; set; }

        public List<TicketMessageDto> Messages { get; set; }
    }
}
