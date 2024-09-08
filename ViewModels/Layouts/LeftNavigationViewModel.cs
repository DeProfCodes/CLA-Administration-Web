using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Layouts
{
    public class LeftNavigationViewModel
    {
        public List<ModuleNameAndPagesViewModel> ModuleNamesPages { get; set; }

        public List<SettingsNamesType> SettingsNamesType { get; set; }
    }
}
