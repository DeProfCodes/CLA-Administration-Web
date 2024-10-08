using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules.ContentLibrary
{
    public class ContentLibraryContentsViewModel
    {
        public int CategoryId { get; set; }

        public ModuleNamesType ModuleName { get; set; }

        public List<ContentLibraryContentModel> ContentLibraryContents { get; set; }
    }
}
