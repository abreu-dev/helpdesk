using HelpDesk.Infra.Core.Entities;

namespace HelpDesk.Infra.DbEntities
{
    public class CategoryData : AuditableEntity
    {
        public static string TABLE_NAME => "Category";
        public static string TABLE_SCHEMA => "dbo";

        public string Name { get; set; }
        
        public Guid? ParentCategoryId { get; set; }
        public virtual CategoryData? ParentCategory { get; set; }
    }
}
