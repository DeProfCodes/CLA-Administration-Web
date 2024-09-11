using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Layouts
{
    public class LeftNavigationViewModel
    {
        public List<DashboardLeftNavigationViewModel> DashboardLeftNavigation { get; set; }

        public List<AdminLeftNavigationViewModel> AdminLeftNavigation { get; set; }

        public List<ModulesLeftNavigationViewModel> ModulesLeftNavigation { get; set; }

        public List<SettingsLeftNavigationViewModel> SettingsLeftNavigation { get; set; }

        public List<ReportsLeftNavigationViewModel> ReportsLeftNavigation { get; set; }

        public List<SupportLeftNavigationViewModel> SupportLeftNavigation { get; set; }

        public List<AccountLeftNavigationViewModel> AccountLeftNavigation { get; set; }
    }
}
