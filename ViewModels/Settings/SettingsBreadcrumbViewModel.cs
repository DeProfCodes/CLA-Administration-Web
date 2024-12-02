using CLA_Administration_Web.Helpers.Enums.AppPages;

namespace CLA_Administration_Web.ViewModels.Settings
{
    public class SettingsBreadcrumbViewModel
    {
        public SettingsPages SettingsCurrentPage { get; set; }

        public bool HasAddNewButton { get; set; }

        public SettingsPages AddNewPage { get; set; }
    }
}
