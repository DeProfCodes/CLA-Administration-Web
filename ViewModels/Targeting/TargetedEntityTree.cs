namespace CLA_Administration_Web.ViewModels.Targeting
{
    public class TargetedEntityTree
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        // List to store child nodes (subcategories)
        public List<TargetedEntityTree> _children { get; set; }

        // This property stores additional data related to the leaf node (like members or details)
        public List<string> GroupDetails { get; set; }  // This can hold group members or any other relevant info
    }
}
