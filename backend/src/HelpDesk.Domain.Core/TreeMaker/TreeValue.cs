using Newtonsoft.Json;

namespace HelpDesk.Domain.Core.TreeMaker
{
    public abstract class TreeValue
    {
        private readonly Guid _id;

        public Guid Id => _id;

        private readonly Guid? _parentId;

        [JsonIgnore]
        public Guid? ParentId => _parentId;

        protected TreeValue(Guid id, Guid? parentId)
        {
            _id = id;
            _parentId = parentId;
        }
    }
}
