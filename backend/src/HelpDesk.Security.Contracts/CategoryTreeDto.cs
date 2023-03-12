using HelpDesk.Domain.Core.TreeMaker;

namespace HelpDesk.Security.Contracts
{
    public class CategoryTreeDto : TreeValue
    {
        public string Name { get; set; }

        public CategoryTreeDto(Guid id, Guid? parentId, string name) : base(id, parentId)
        {
            Name = name;
        }
    }
}
