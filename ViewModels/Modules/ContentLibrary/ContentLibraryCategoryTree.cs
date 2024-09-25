namespace CLA_Administration_Web.ViewModels.Modules.ContentLibrary
{
    public class ContentLibraryCategoryTree
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public int ContentsCount { get; set; }

        public List<ContentLibraryCategoryTree> _children { get; set; }
    }
}
