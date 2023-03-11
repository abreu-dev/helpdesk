namespace HelpDesk.Infra.Core.Entities
{
    public abstract class AuditableEntity : DataEntity
    {
        public DateTimeOffset CreatedOn { get; set; }
        public DateTimeOffset? LastModifiedOn { get; set; }

        public AuditableEntity()
        {
            CreatedOn = DateTimeOffset.MinValue;
        }

        public void OnCreate()
        {
            CreatedOn = DateTimeOffset.UtcNow;
        }

        public void OnModified()
        {
            LastModifiedOn = DateTimeOffset.UtcNow;
        }
    }
}
