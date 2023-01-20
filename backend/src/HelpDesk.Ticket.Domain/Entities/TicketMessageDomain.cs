using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.ProtectSkills;
using HelpDesk.Core.Domain.ProtectSkills.Skills;

namespace HelpDesk.Ticket.Domain.Entities
{
    public class TicketMessageDomain : DomainEntity
    {
        private Guid _id;
        public Guid Id
        {
            get => _id;
            private set
            {
                _id = value;
            }
        }

        private Guid _ticketId;
        public Guid TicketId
        {
            get => _ticketId;
            private set
            {
                _ticketId = value;
            }
        }

        private Guid _ownerId;
        public Guid OwnerId
        {
            get => _ownerId;
            private set
            {
                _ownerId = value;
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            private set
            {
                _message = Protect<string>
                    .Property(nameof(Message), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        public TicketMessageDomain(Guid ticketId,
                                   Guid ownerId,
                                   string message)
        {
            Id = Guid.NewGuid();
            TicketId = ticketId;
            OwnerId = ownerId;
            Message = message;
        }

        public TicketMessageDomain(Guid id,
                                   Guid ticketId,
                                   Guid ownerId,
                                   string message)
            : this(ticketId, ownerId, message)
        {
            Id = id;
        }
    }
}
