﻿namespace HelpDesk.Ticket.Contracts
{
    public class TicketMessageOwnerDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
