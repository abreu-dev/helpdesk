using HelpDesk.Core.Infra.Data.Entities;

namespace HelpDesk.Infra.DbEntities
{
    public class TicketData : AuditableEntity
    {
        public Guid CustomerId { get; set; }
        public UserData Customer { get; set; }

        public Guid AttendantId { get; set; }
        public UserData Attendant { get; set; }

        public string Title { get; set; }

        public virtual ICollection<TicketMessageData> Messages { get; set; }
    }
}
