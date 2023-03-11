using HelpDesk.Domain.Core.Entities;

namespace HelpDesk.Security.Domain.Entities
{
    public class UnitDomain : DomainEntity
    {
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
