using HelpDesk.Core.Domain.ProtectSkills;

namespace HelpDesk.Core.Domain.Entities
{
    public abstract class ProtectedDomainEntity
    {
        public ICollection<IProtectSkill> ProtectSkills { get; set; } = new List<IProtectSkill>();
        
        public Protect<TPropertyValue> CreateProtection<TPropertyValue>(string propertyName, TPropertyValue value)
        {
            var protect = Protect<TPropertyValue>.Property(propertyName, value);
            ProtectSkills.Add(protect);
            return protect;
        }
    }
}
