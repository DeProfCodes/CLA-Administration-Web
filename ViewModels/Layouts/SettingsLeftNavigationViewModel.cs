using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Layouts
{
    public class SettingsLeftNavigationViewModel
    {
        public SettingsNamesType SettingName { get; set; }

        public SettingsPages SettingsPage { get; set; }

        public string IconWhiteUrl { get; set; }

        public string IconBlueUrl { get; set; }
    }
}
