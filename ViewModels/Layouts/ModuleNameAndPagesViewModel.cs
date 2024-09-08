using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Layouts
{
    public class ModuleNameAndPagesViewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public ModulesPages OverviewPage { get; set; }

        public ModulesPages AddNewPage { get; set; }

        public string IconWhiteUrl { get; set; }

        public string IconBlueUrl { get; set; }
    }
}
