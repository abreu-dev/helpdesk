using HelpDesk.Core.Infra.Data.Entities;

namespace HelpDesk.Infra.DbEntities
{
    public class TicketMessageData : AuditableEntity
    {
        public Guid TicketId { get; set; }
        public TicketData Ticket { get; set; }

        public Guid OwnerId { get; set; }
        public UserData Owner { get; set; }
        
        public string Message { get; set; }
    }
}
