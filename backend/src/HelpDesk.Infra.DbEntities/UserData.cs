using HelpDesk.Core.Infra.Data.Entities;
using HelpDesk.Infra.Globalization;

namespace HelpDesk.Infra.DbEntities
{
    public class UserData : AuditableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Language Language { get; set; }

        public virtual ICollection<TicketData> TicketsAsCustomer { get; set; }
        public virtual ICollection<TicketData> TicketsAsAttendant { get; set; }
    }
}
