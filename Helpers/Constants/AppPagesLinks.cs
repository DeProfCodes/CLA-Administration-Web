namespace CLA_Administration_Web.Helpers.Constants
{
    public class AppPagesLinks
    {
        public class Admin
        {
            public const string UploadFilesPageLink = "~/Views/Admin/UploadFiles.cshtml";
            public const string ApplicationParametersPageLink = "~/Views/Admin/ApplicationParameters.cshtml";
            public const string LicensingPageLink = "~/Views/Admin/Licensing.cshtml";
            public const string AutoRemindersPageLink = "~/Views/Admin/AutoReminders.cshtml";
            public const string SQLBrowserPageLink = "~/Views/Admin/SQLBrowser.cshtml";
        }

        public class Account
        {
            public const string AccountOverviewPageLink = "~/Views/Account/AccountOverview.cshtml";
            public const string SecuritySettingsPageLink = "~/Views/Account/SecuritySettings.cshtml";
        }

        public class Layouts
        {
            public const string TopNavigationPageLink = "~/Views/Layout/TopNavigation.cshtml";
            public const string LeftNavigationPageLink = "~/Views/Layout/LeftNavigation.cshtml";
        }

        public class Dashboard
        {
            public const string DashboardHomePageLink = "~/Views/Dashboard/Home.cshtml";
            public const string DashboardCalendarPageLink = "~/Views/Dashboard/Calendar.cshtml";
        }

        public class Modules
        {
            public const string AllModulesPageLink = "~/Views/Modules/AllModules.cshtml";

            public const string ContentLibraryCategoriesPageLink = "~/Views/Modules/ContentLibrary/Categories.cshtml";
            public const string ContentLibraryContentsPageLink = "~/Views/Modules/ContentLibrary/Contents.cshtml";

            public const string DesktopOverviewPageLink = "~/Views/Modules/Desktop/Overview.cshtml";
            public const string DesktopAddNewPageLink = "~/Views/Modules/Desktop/AddNew.cshtml";

            public const string LockedDesktopOverviewPageLink = "~/Views/Modules/LockedDesktop/Overview.cshtml";
            public const string LockedDesktopAddNewPageLink = "~/Views/Modules/LockedDesktop/AddNew.cshtml";

            public const string ScreensaverOverviewPageLink = "~/Views/Modules/Screensaver/Overview.cshtml";
            public const string ScreensaverAddNewPageLink = "~/Views/Modules/Screensaver/AddNew.cshtml";

            public const string PopupOverviewPageLink = "~/Views/Modules/Popup/PopupOverview.cshtml";
            public const string PopupAddNewPageLink = "~/Views/Modules/Popup/AddNewPopup.cshtml";

            public const string SurveyOverviewPageLink = "~/Views/Modules/Survey/Overview.cshtml";
            public const string SurveyAddNewPageLink = "~/Views/Modules/Survey/AddNew.cshtml";

            public const string TickerOverviewPageLink = "~/Views/Modules/Ticker/Overview.cshtml";
            public const string TickerAddNewPageLink = "~/Views/Modules/Ticker/AddNew.cshtml";

            public const string RSSOverviewPageLink = "~/Views/Modules/RSS/Overview.cshtml";
            public const string RSSAddNewPageLink = "~/Views/Modules/RSS/AddNew.cshtml";
        }

        public class Settings
        {
            public const string StagingUsersPageLink = "~/Views/Settings/StagingUsers.cshtml";
            public const string SetupExclusionsPageLink = "~/Views/Settings/SetupExclusions.cshtml";
            public const string AdminAccessPageLink = "~/Views/Settings/AdminAccess.cshtml";
            public const string TargetGroupsPageLink = "~/Views/Settings/TargetGroups.cshtml";
            public const string CustomUserSettingsPageLink = "~/Views/Settings/CustomUserSettings.cshtml";
            public const string ActiveConnectionsPageLink = "~/Views/Settings/ActiveConnections.cshtml";
            public const string SkinsOfflineImagesPageLink = "~/Views/Settings/SkinsOfflineImages.cshtml";
            public const string DesktopInformationPageLink = "~/Views/Settings/DesktopInformation.cshtml";
        }

        public class Reports
        {
            public const string SurveyPageLink = "~/Views/Reports/Survey.cshtml";
            public const string PopupPageLink = "~/Views/Reports/Popup.cshtml";
            public const string TickerPageLink = "~/Views/Reports/Ticker.cshtml";
            public const string PolicyPageLink = "~/Views/Reports/Policy.cshtml";
            public const string ActiveUsersPageLink = "~/Views/Reports/ActiveUsers.cshtml";
            public const string ActiveMachinesPageLink = "~/Views/Reports/ActiveMachines.cshtml";
            public const string CampaignDispatchPageLink = "~/Views/Reports/CampaignDispatch.cshtml";
            public const string TroubleshootPageLink = "~/Views/Reports/Troubleshoot.cshtml";
        }

        public class Support
        {
            public const string AboutUsPageLink = "~/Views/Support/AboutUs.cshtml";
            public const string TutorialsPageLink = "~/Views/Support/Tutorials.cshtml";
            public const string RemoteAssistancePageLink = "~/Views/Support/RemoteAssistance.cshtml";
            public const string ContactUsPageLink = "~/Views/Support/ContactUs.cshtml";
            public const string FAQPageLink = "~/Views/Support/FAQ.cshtml";
        }

    }
}
