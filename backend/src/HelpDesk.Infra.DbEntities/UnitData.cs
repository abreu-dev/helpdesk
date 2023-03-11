using HelpDesk.Infra.Core.Entities;

namespace HelpDesk.Infra.DbEntities
{
    public class UnitData : AuditableEntity
    {
        public static string TABLE_NAME => "Unit";
        public static string TABLE_SCHEMA => "dbo";

        public string Name { get; set; }
        public string Code { get; set; }
    }
}
