namespace CLA_Administration_Web.ViewModels.Modules.ContentLibrary
{
    public class ContentLibraryCategoryModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public int ContentsCount { get; set; }

        public string UserLastModified { get; set; }

        public string MachineLastModified { get; set; }
    }
}
