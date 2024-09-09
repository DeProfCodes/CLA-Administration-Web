using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Helpers.Constants
{
    public class AppPagesUrl
    {
        public const string dashboardController = "Dashboard";
        public const string modulesController = "Modules";
        public const string settingsController = "Settings";
        public const string reportsController = "Reports";

        public class Dashboard
        {
            public static string Home = $"/{dashboardController}/{DashboardPages.Dashboard.GetDisplayName()}";
            public static string Calendar = $"/{dashboardController}/{DashboardPages.Calendar.GetDisplayName()}";
        }

        public class Modules
        {
            public static string ContentLibraryCategories = $"/{modulesController}/{ModulesPages.ContentLibraryCategories.GetDisplayName()}";
            public static string ContentLibraryContent = $"/{modulesController}/{ModulesPages.ContentLibraryContent.GetDisplayName()}";

            public static string DesktopOverview = $"/{modulesController}/{ModulesPages.DesktopOverview.GetDisplayName()}";
            public static string DesktopAddNew = $"/{modulesController}/{ModulesPages.DesktopAddNew.GetDisplayName()}";

            public static string LockedDesktopOverview = $"/{modulesController}/{ModulesPages.LockedDesktopOverview.GetDisplayName()}";
            public static string LockedDesktopAddNew = $"/{modulesController}/{ModulesPages.LockedDesktopAddNew.GetDisplayName()}";

            public static string ScreensaverOverview = $"/{modulesController}/{ModulesPages.ScreensaverOverview.GetDisplayName()}";
            public static string ScreensaverAddNew = $"/{modulesController}/{ModulesPages.ScreensaverAddNew.GetDisplayName()}";

            public static string PopupOverview = $"/{modulesController}/{ModulesPages.PopupOverview.GetDisplayName()}";
            public static string PopupAddNew = $"/{modulesController}/{ModulesPages.PopupAddNew.GetDisplayName()}";

            public static string SurveyOverview = $"/{modulesController}/{ModulesPages.SurveyOverview.GetDisplayName()}";
            public static string SurveyAddNew = $"/{modulesController}/{ModulesPages.SurveyAddNew.GetDisplayName()}";

            public static string TickerOverview = $"/{modulesController}/{ModulesPages.TickerOverview.GetDisplayName()}";
            public static string TickerAddNew = $"/{modulesController}/{ModulesPages.TickerAddNew.GetDisplayName()}";

            public static string RSSOverview = $"/{modulesController}/{ModulesPages.RSSOverview.GetDisplayName()}";
            public static string RSSAddNew = $"/{modulesController}/{ModulesPages.RSSAddNew.GetDisplayName()}";
        }

        public class Setttings
        {
            public static string StagingUsers = $"/{settingsController}/{SettingsPages.StagingUsers.GetDisplayName()}";
            public static string SetupExclusions = $"/{settingsController}/{SettingsPages.SetupExclusions.GetDisplayName()}";
            public static string AdminAccess = $"/{settingsController}/{SettingsPages.AdminAccess.GetDisplayName()}";
            public static string TargetGroups = $"/{settingsController}/{SettingsPages.TargetGroups.GetDisplayName()}";
            public static string CustomUserSettings = $"/{settingsController}/{SettingsPages.CustomUserSettings.GetDisplayName()}";
            public static string ActiveConnections = $"/{settingsController}/{SettingsPages.ActiveConnections.GetDisplayName()}";
            public static string SkinsOfflineImages = $"/{settingsController}/{SettingsPages.SkinsOfflineImages.GetDisplayName()}";
            public static string DesktopInformation = $"/{settingsController}/{SettingsPages.DesktopInformation.GetDisplayName()}";
        }

        public class Reports
        {
            public static string Survey = $"/{reportsController}/{ReportsPages.Survey.GetDisplayName()}";
            public static string Popup = $"/{reportsController}/{ReportsPages.Popup.GetDisplayName()}";
            public static string Ticker = $"/{reportsController}/{ReportsPages.Ticker.GetDisplayName()}";
            public static string Policy = $"/{reportsController}/{ReportsPages.Policy.GetDisplayName()}";
            public static string ActiveUsers = $"/{reportsController}/{ReportsPages.ActiveUsers.GetDisplayName()}";
            public static string ActiveMachines = $"/{reportsController}/{ReportsPages.ActiveMachines.GetDisplayName()}";
            public static string CampaignDispatch = $"/{reportsController}/{ReportsPages.CampaignDispatch.GetDisplayName()}";
            public static string Troubleshoot = $"/{reportsController}/{ReportsPages.Troubleshoot.GetDisplayName()}";
        }
    }
}
