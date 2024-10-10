namespace CLA_Administration_Web.ViewModels.Targeting
{
    public class TargetedEntityTree
    {
        public int Id { get; set; }

        public string EntityName { get; set; }

        public List<TargetedEntityTree> _children { get; set; }
    }
}
