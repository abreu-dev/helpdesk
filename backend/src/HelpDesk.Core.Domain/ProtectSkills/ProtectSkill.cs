namespace HelpDesk.Core.Domain.ProtectSkills
{
    public interface IProtectSkill<TPropertyValue>
    {
        public string PropertyName { get; set; }
        public TPropertyValue PropertyValue { get; set; }
    }

    public class Protect<TPropertyValue> : IProtectSkill<TPropertyValue>
    {
        public string PropertyName { get; set; }
        public TPropertyValue PropertyValue { get; set; }

        public Protect(string propertyName, TPropertyValue propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

        public static Protect<TPropertyValue> Property(string propertyName, TPropertyValue propertyValue) => new(propertyName, propertyValue);

        public IProtectSkill<TPropertyValue> Against => this;
    }

}
