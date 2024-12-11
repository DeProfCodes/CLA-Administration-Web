using CLA_Administration_Web.Helpers.Enums.AppPages;

namespace CLA_Administration_Web.ViewModels.Settings.Shared
{
    public class SettingsBreadcrumbViewModel
    {
        public SettingsPages SettingsCurrentPage { get; set; }

        public bool HasAddNewButton { get; set; }

        public string BreadcrumbButtonName { get; set; }

        public string BreadcrumbButtonCallbackFunction { get; set; }
    }
}
