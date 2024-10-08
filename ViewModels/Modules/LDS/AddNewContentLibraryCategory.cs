using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;

namespace CLA_Administration_Web.ViewModels.Modules.LDS
{
    public class AddNewContentLibraryCategory
    {
        public int CategoryId { get; set; }

        public string ContentLibraryParents { get; set; }

        public string CategoryName { get; set; }

        public List<ContentLibraryCategoryModel> ContentCategories { get; set; }

        public ModuleNamesType ModuleName { get; set; }
    }
}
