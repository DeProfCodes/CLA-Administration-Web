using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;

namespace CLA_Administration_Web.ViewModels.Settings.SkinAndOfflineImage
{
    public class SkinOfflineCategortyTree
    {
        public int CategoryId { get; set; }
        public string ParentCategoryName { get; set; }

        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public int ContentsCount { get; set; }
        public string UserLastModified { get; set; }
        public string MachineLastModified { get; set; }

        public List<SkinOfflineCategortyTree> _children { get; set; }
        public List<SkinOfflineCategortyTree> _SubCategoryName { get; set; }


    }
}
