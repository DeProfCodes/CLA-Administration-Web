using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Modules
{
    public class ModuleBreadcrumbViewModel
    {
        public string ModuleName { get; set; }

        public string ModuleSubPage { get; set; }

        public ModulesPages ModulePage { get; set; }

        public string ModulePageName { get; set; }

        public bool IsAllModulesBreadcrumb { get; set; }

        public bool IsDetailsPage {get; set; }

        public int ModuleDetailsId { get; set; }

        public ModulesPages ModulePreviewPage { get; set; }

        public bool HasActionButton { get; set; }

        public bool IsAddNewIcon { get; set; }

        public string ActionButtonText { get; set; }

        public ModulesPages ActionButtonPage { get; set; }

    }
}
