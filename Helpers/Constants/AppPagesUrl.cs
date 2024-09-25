using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Helpers.Constants
{
    public class AppPagesUrl
    {
        public static string BaseAddress = LaunchSettingsHelper.GetBaseAddressForControllers();

        public static string adminController = $"{BaseAddress}Admin";
        public static string accountController = $"{BaseAddress}Account";
        public static string dashboardController = $"{BaseAddress}Dashboard";
        public static string modulesController = $"{BaseAddress}Modules";
        public static string settingsController = $"{BaseAddress}Settings";
        public static string reportsController = $"{BaseAddress}Reports";
        public static string supportController = $"{BaseAddress}Support";

        public class Admin
        {
            public static string UploadFiles = $"/{adminController}/{AdminPages.UploadFiles}";
            public static string ApplicationParameters = $"/{adminController}/{AdminPages.ApplicationParameters}";
            public static string Licensing = $"/{adminController}/{AdminPages.Licensing}";
            public static string AutoReminders = $"/{adminController}/{AdminPages.AutoReminders}";
            public static string SQLBrowser = $"/{adminController}/{AdminPages.SQLBrowser}";
        }

        public class Account
        {
            public static string AccountOverview = $"/{accountController}/{AccountPages.AccountOverview}";
            public static string SecuritySettings = $"/{accountController}/{AccountPages.SecuritySettings}";
        }

        public class Dashboard
        {
            public static string Home = $"/{dashboardController}/{DashboardPages.Dashboard.GetDisplayName()}";
            public static string Calendar = $"/{dashboardController}/{DashboardPages.Calendar.GetDisplayName()}";
        }

        public class Modules
        {
            //All
            public static string AllModules = $"/{modulesController}/{ModulesPages.AllModules.GetDisplayName()}";

            //PSTR Modules: Popup, Survey, Ticker, RSS
            public static string ModulePSTRTableOverview = $"/{modulesController}/{ModulesPages.ModulePSTRTableOverview.GetDisplayName()}";
            
            //LDS Modules: Lockscreen, Desktop, Screensaver
            public static string ModuleLDSTableOverview = $"/{modulesController}/{ModulesPages.ModuleLDSTableOverview.GetDisplayName()}";
            public static string ModuleLDSCalendarOverview = $"/{modulesController}/{ModulesPages.ModuleLDSCalendarOverview.GetDisplayName()}";
            public static string ModuleLDSGanttOverview = $"/{modulesController}/{ModulesPages.ModuleLDSGanttOverview.GetDisplayName()}";

            //Content Library
            public static string ContentLibraryCategories = $"/{modulesController}/{ModulesPages.ContentLibraryCategories.GetDisplayName()}";
            public static string ContentLibraryContent = $"/{modulesController}/{ModulesPages.ContentLibraryContent.GetDisplayName()}";

            //Desktop
            public static string DesktopOverview = $"/{modulesController}/{ModulesPages.DesktopOverview.GetDisplayName()}";
            public static string DesktopAddNew = $"/{modulesController}/{ModulesPages.DesktopAddNew.GetDisplayName()}";

            //Locked Desktop
            public static string LockedDesktopOverview = $"/{modulesController}/{ModulesPages.LockedDesktopOverview.GetDisplayName()}";
            public static string LockedDesktopAddNew = $"/{modulesController}/{ModulesPages.LockedDesktopAddNew.GetDisplayName()}";

            //Screensaver
            public static string ScreensaverOverview = $"/{modulesController}/{ModulesPages.ScreensaverOverview.GetDisplayName()}";
            public static string ScreensaverAddNew = $"/{modulesController}/{ModulesPages.ScreensaverAddNew.GetDisplayName()}";

            //Popup
            public static string PopupOverview = $"/{modulesController}/{ModulesPages.PopupOverview.GetDisplayName()}";
            public static string PopupDetails = $"/{modulesController}/{ModulesPages.PopupDetails.GetDisplayName()}";
            public static string PopupAddNew = $"/{modulesController}/{ModulesPages.PopupAddNew.GetDisplayName()}";

            //Survey
            public static string SurveyOverview = $"/{modulesController}/{ModulesPages.SurveyOverview.GetDisplayName()}";
            public static string SurveyDetails = $"/{modulesController}/{ModulesPages.SurveyDetails.GetDisplayName()}";
            public static string SurveyQuestionsOverview = $"/{modulesController}/{ModulesPages.SurveyQuestionsOverview.GetDisplayName()}";
            public static string SurveyQuestionDetails = $"/{modulesController}/{ModulesPages.SurveyQuestionDetails.GetDisplayName()}";
            public static string SurveyAddNew = $"/{modulesController}/{ModulesPages.SurveyAddNew.GetDisplayName()}";

            //Ticker
            public static string TickerOverview = $"/{modulesController}/{ModulesPages.TickerOverview.GetDisplayName()}";
            public static string TickerDetails = $"/{modulesController}/{ModulesPages.TickerDetails.GetDisplayName()}";
            public static string TickerAddNew = $"/{modulesController}/{ModulesPages.TickerAddNew.GetDisplayName()}";

            //RSS
            public static string RSSCategoryOverview = $"/{modulesController}/{ModulesPages.RSSCategoryOverview.GetDisplayName()}";
            public static string RSSCategoryDetails = $"/{modulesController}/{ModulesPages.RSSCategoryDetails.GetDisplayName()}";
            public static string RSSFeedOverview = $"/{modulesController}/{ModulesPages.RSSFeedOverview.GetDisplayName()}";
            public static string RSSFeedDetails = $"/{modulesController}/{ModulesPages.RSSFeedDetails.GetDisplayName()}";
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

        public class Support
        {
            public static string AboutUs = $"/{supportController}/{SupportPages.AboutUs.GetDisplayName()}";
            public static string Tutorials = $"/{supportController}/{SupportPages.Tutorials.GetDisplayName()}";
            public static string RemoteAssistance = $"/{supportController}/{SupportPages.RemoteAssistance.GetDisplayName()}";
            public static string ContactUs = $"/{supportController}/{SupportPages.ContactUs.GetDisplayName()}";
            public static string FAQ = $"/{supportController}/{SupportPages.FAQ.GetDisplayName()}";
        }
    }
}
