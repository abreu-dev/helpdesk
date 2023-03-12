namespace HelpDesk.Domain.Core.TreeMaker
{
    public class TreeNode<TTreeType> where TTreeType : TreeValue
    {
        public TTreeType Value { get; set; }
        public List<TreeNode<TTreeType>> Children { get; set; }

        public TreeNode(TTreeType value)
        {
            Value = value;
            Children = new List<TreeNode<TTreeType>>();
        }

        public void AddChildren(List<IGrouping<Guid?, TTreeType>> groupedValues)
        {
            var parentValues = groupedValues.SingleOrDefault(x => x.Key == Value.Id);

            if (parentValues != null && parentValues.Any())
            {
                var children = parentValues.Select(value => new TreeNode<TTreeType>(value));
                Children.AddRange(children);

                foreach (var child in Children)
                {
                    child.AddChildren(groupedValues);
                }
            }
        }
    }
}
