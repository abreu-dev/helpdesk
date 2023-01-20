using HelpDesk.Core.Domain.Entities;
using HelpDesk.Core.Domain.ProtectSkills;
using HelpDesk.Core.Domain.ProtectSkills.Skills;

namespace HelpDesk.Ticket.Domain.Entities
{
    public class TicketDomain : DomainEntity
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

        private Guid _customerId;
        public Guid CustomerId
        {
            get => _customerId;
            private set
            {
                _customerId = value;
            }
        }

        private Guid _attendantId;
        public Guid AttendantId
        {
            get => _attendantId;
            private set
            {
                _attendantId = value;
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            private set
            {
                _title = Protect<string>
                    .Property(nameof(Title), value)
                    .Against
                    .NullOrEmpty()
                    .PropertyValue;
            }
        }

        private readonly List<TicketMessageDomain> _messages = new();
        public virtual IReadOnlyCollection<TicketMessageDomain> Messages => _messages;

        public TicketDomain(Guid customerId,
                            Guid attendantId,
                            string title)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            AttendantId = attendantId;
            Title = title;
        }

        public TicketDomain(Guid id,
                            Guid customerId,
                            Guid attendantId,
                            string title,
                            List<TicketMessageDomain> messages)
            : this(customerId, attendantId, title)
        {
            Id = id;
            _messages = messages;
        }

        public void AddMessage(Guid ownerId, string message)
        {
            var newMessage = new TicketMessageDomain(Id, ownerId, message);
            _messages.Add(newMessage);
        }
    }
}
