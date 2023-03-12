namespace HelpDesk.Domain.Core.TreeMaker
{
    public class TreeView<TTreeType> where TTreeType : TreeValue
    {
        public List<TreeNode<TTreeType>> Children { get; set; }

        public TreeView(List<TTreeType> values)
        {
            Children = new List<TreeNode<TTreeType>>();
            Build(values);
        }

        private void Build(List<TTreeType> values)
        {
            var rootValues = values.Where(x => !x.ParentId.HasValue).ToList();
            var nodeValues = values.Except(rootValues).GroupBy(x => x.ParentId).ToList();

            foreach (var rootValue in rootValues)
            {
                var treeNode = new TreeNode<TTreeType>(rootValue);
                treeNode.AddChildren(nodeValues);
                Children.Add(treeNode);
            }
        }
    }
}
