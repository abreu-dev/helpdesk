namespace HelpDesk.Core.Domain.ProtectSkills
{
    public interface IProtectSkill
    {
        string PropertyName { get; set; }
        List<AppliedSkill> AppliedSkills { get; set; }

        void AddAppliedSkill(string skillName);
    }

    public interface IProtectSkill<TPropertyValue> : IProtectSkill
    {
        public TPropertyValue PropertyValue { get; set; }
    }

    public class Protect<TPropertyValue> : IProtectSkill<TPropertyValue>
    {
        public string PropertyName { get; set; }
        public TPropertyValue PropertyValue { get; set; }
        public List<AppliedSkill> AppliedSkills { get; set; }

        public Protect(string propertyName, TPropertyValue propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
            AppliedSkills = new List<AppliedSkill>();
        }

        public static Protect<TPropertyValue> Property(string propertyName, TPropertyValue propertyValue) => new(propertyName, propertyValue);

        public IProtectSkill<TPropertyValue> Against => this;

        public void AddAppliedSkill(string skillName)
        {
            var newAppliedSkill = new AppliedSkill(skillName);
            AppliedSkills.Add(newAppliedSkill);
        }
    }
}
