using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Helpers.Constants
{
    public class AppPagesUrl
    {
        public static string BaseAddress = LaunchSettingsHelper.GetBaseAddressForControllers();

        public static string adminController = $"{BaseAddress}Admin";
        public static string targetingController = $"{BaseAddress}Targeting";
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

        public class Targeting
        {
            public static string TargetedEntities = $"/{targetingController}/{TargetingPages.TargetedEntities}";
            public static string TargetingExposure = $"/{targetingController}/{TargetingPages.TargetingExposure}";
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

            //PST Modules: Popup, Survey, Ticker
            public static string ModulePSTTableOverview = $"/{modulesController}/{ModulesPages.ModulePSTTableOverview.GetDisplayName()}";
            
            //LDS Modules: Lockscreen, Desktop, Screensaver
            public static string ModuleLDSTableOverview = $"/{modulesController}/{ModulesPages.ModuleLDSTableOverview.GetDisplayName()}";
            public static string ModuleLDSCalendarOverview = $"/{modulesController}/{ModulesPages.ModuleLDSCalendarOverview.GetDisplayName()}";
            public static string ModuleLDSGanttOverview = $"/{modulesController}/{ModulesPages.ModuleLDSGanttOverview.GetDisplayName()}";
            public static string AddNewLDSModuleTableOverview = $"/{modulesController}/{ModulesPages.AddNewLDSModule.GetDisplayName()}";

            //Content Library
            public static string ContentLibraryCategories = $"/{modulesController}/{ModulesPages.ContentLibraryCategories.GetDisplayName()}";
            public static string ContentLibraryCategoryDetails = $"/{modulesController}/{ModulesPages.ContentLibraryCategoryDetails.GetDisplayName()}";
            public static string AddNewContentLibraryCategory = $"/{modulesController}/{ModulesPages.AddNewContentLibraryCategory.GetDisplayName()}";
            public static string ContentLibraryContent = $"/{modulesController}/{ModulesPages.ContentLibraryContent.GetDisplayName()}";
            public static string ContentLibraryContentDetails = $"/{modulesController}/{ModulesPages.ContentLibraryContentDetails.GetDisplayName()}";
            public static string AddNewContentLibraryContent = $"/{modulesController}/{ModulesPages.AddNewContentLibraryContent.GetDisplayName()}";

            //Desktop
            public static string DesktopOverview = $"/{modulesController}/{ModulesPages.DesktopOverview.GetDisplayName()}";
            public static string DesktopDetails = $"/{modulesController}/{ModulesPages.DesktopDetails.GetDisplayName()}";
            public static string DesktopAddNew = $"/{modulesController}/{ModulesPages.DesktopAddNew.GetDisplayName()}";

            //Locked Desktop
            public static string LockedDesktopOverview = $"/{modulesController}/{ModulesPages.LockedDesktopOverview.GetDisplayName()}";
            public static string LockedDesktopDetails = $"/{modulesController}/{ModulesPages.LockedDesktopDetails.GetDisplayName()}";
            public static string LockedDesktopAddNew = $"/{modulesController}/{ModulesPages.LockedDesktopAddNew.GetDisplayName()}";

            //Screensaver
            public static string ScreensaverOverview = $"/{modulesController}/{ModulesPages.ScreensaverOverview.GetDisplayName()}";
            public static string ScreensaverDetails = $"/{modulesController}/{ModulesPages.ScreensaverDetails.GetDisplayName()}";
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
            public static string AddNewSurveyQuestion = $"/{modulesController}/{ModulesPages.AddNewSurveyQuestion.GetDisplayName()}";

            //Ticker
            public static string TickerOverview = $"/{modulesController}/{ModulesPages.TickerOverview.GetDisplayName()}";
            public static string TickerDetails = $"/{modulesController}/{ModulesPages.TickerDetails.GetDisplayName()}";
            public static string TickerAddNew = $"/{modulesController}/{ModulesPages.TickerAddNew.GetDisplayName()}";

            //RSS
            public static string RSSCategoryOverview = $"/{modulesController}/{ModulesPages.RSSCategoryOverview.GetDisplayName()}";
            public static string RSSCategoryDetails = $"/{modulesController}/{ModulesPages.RSSCategoryDetails.GetDisplayName()}";
            public static string RSSFeedOverview = $"/{modulesController}/{ModulesPages.RSSFeedOverview.GetDisplayName()}";
            public static string RSSFeedDetails = $"/{modulesController}/{ModulesPages.RSSFeedDetails.GetDisplayName()}";
            public static string RSSAddNewCategory = $"/{modulesController}/{ModulesPages.RSSAddNewCategory.GetDisplayName()}";
            public static string RSSAddNewFeed = $"/{modulesController}/{ModulesPages.RSSAddNewFeed.GetDisplayName()}";

            //Additional Components
            public static string ModuleContentPreviewer = $"/{modulesController}/{ModulesPages.ModuleContentPreviewer.GetDisplayName()}";
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
            public static string ReportModulesListing = $"/{reportsController}/{ReportsPages.ReportModulesListing.GetDisplayName()}";
            public static string ExportFileToExcel = $"/{reportsController}/{ReportsPages.ExportFileToExcel.GetDisplayName()}";
            public static string Survey = $"/{reportsController}/{ReportsPages.SurveyReport.GetDisplayName()}";
            public static string SurveyExport = $"/{reportsController}/{ReportsPages.SurveyReportForExport.GetDisplayName()}";
            public static string SurveyReportOnly = $"/{reportsController}/{ReportsPages.SurveyReportOnly.GetDisplayName()}";
            public static string Popup = $"/{reportsController}/{ReportsPages.PopupReport.GetDisplayName()}";
            public static string PopupExport = $"/{reportsController}/{ReportsPages.PopupReportForExport.GetDisplayName()}";
            public static string PopupReportOnly = $"/{reportsController}/{ReportsPages.PopupReportOnly.GetDisplayName()}";
            public static string Ticker = $"/{reportsController}/{ReportsPages.TickerReport.GetDisplayName()}";
            public static string TickerExport = $"/{reportsController}/{ReportsPages.TickerReportForExport.GetDisplayName()}";
            public static string TickerReportOnly = $"/{reportsController}/{ReportsPages.TickerReportOnly.GetDisplayName()}";
            public static string Policy = $"/{reportsController}/{ReportsPages.PolicyReport.GetDisplayName()}"; 
            public static string PolicyExport = $"/{reportsController}/{ReportsPages.PolicyReportForExport.GetDisplayName()}";
            public static string PolicyReportOnly = $"/{reportsController}/{ReportsPages.PolicyReportOnly.GetDisplayName()}";
            public static string ActiveUsers = $"/{reportsController}/{ReportsPages.ActiveUsersReport.GetDisplayName()}";
            public static string ActiveMachines = $"/{reportsController}/{ReportsPages.ActiveMachinesReport.GetDisplayName()}";
            public static string ActiveUsersMachines = $"/{reportsController}/{ReportsPages.ActiveUsersMachinesReport.GetDisplayName()}";
            public static string CampaignDispatch = $"/{reportsController}/{ReportsPages.CampaignDispatchReport.GetDisplayName()}";
            public static string CampaignDispatchList = $"/{reportsController}/{ReportsPages.CampaignDispatchListReport.GetDisplayName()}";
            public static string Troubleshoot = $"/{reportsController}/{ReportsPages.TroubleshootReport.GetDisplayName()}";
            public static string TroubleshootData = $"/{reportsController}/{ReportsPages.TroubleshootReportData.GetDisplayName()}";
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
