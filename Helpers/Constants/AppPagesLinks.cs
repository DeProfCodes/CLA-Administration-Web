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
            //All
            public const string AllModulesPageLink = "~/Views/Modules/AllModules.cshtml";

            //PSTR Modules: Popup, Survey, Ticker, RSS
            public const string ModulePSTRTableOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/PSTR/ModulePSTRTableOverview.cshtml";
            
            //LDS Modules: Lockscreen, Desktop, Screensaver 
            public const string ModuleLDSTableOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSTableOverview.cshtml";
            public const string ModuleLDSGanttOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSGanttOverview.cshtml";
            public const string ModuleLDSCalendarOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSCalendarOverview.cshtml";

            //Content Library
            public const string ContentLibraryCategoriesPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryCategories.cshtml";
            public const string ContentLibraryCategoryDetailsPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryCategoryDetails.cshtml";
            public const string ContentLibraryContentsPageLink = "~/Views/Modules/ContentLibrary/Contents.cshtml";

            //Desktop
            public const string DesktopOverviewPageLink = "~/Views/Modules/Desktop/DesktopOverview.cshtml";
            public const string DesktopAddNewPageLink = "~/Views/Modules/Desktop/AddNewDesktop.cshtml";

            //Locked Desktop
            public const string LockedDesktopOverviewPageLink = "~/Views/Modules/LockedDesktop/LockedDesktopOverview.cshtml";
            public const string LockedDesktopAddNewPageLink = "~/Views/Modules/LockedDesktop/AddNewLockedDesktop.cshtml";

            //Screensaver
            public const string ScreensaverOverviewPageLink = "~/Views/Modules/Screensaver/ScreensaverOverview.cshtml";
            public const string ScreensaverAddNewPageLink = "~/Views/Modules/Screensaver/AddNewScreensaver.cshtml";

            //Popup
            public const string PopupOverviewPageLink = "~/Views/Modules/Popup/PopupOverview.cshtml";
            public const string PopupDetailsPageLink = "~/Views/Modules/Popup/PopupDetails.cshtml";
            public const string PopupAddNewPageLink = "~/Views/Modules/Popup/AddNewPopup.cshtml";

            //Survey
            public const string SurveyOverviewPageLink = "~/Views/Modules/Survey/SurveyOverview.cshtml";
            public const string SurveyDetailsPageLink = "~/Views/Modules/Survey/SurveyDetails.cshtml";
            public const string SurveyQuestionsOverviewPageLink = "~/Views/Modules/Survey/SurveyQuestionsOverview.cshtml";
            public const string SurveyQuestionDetailsPageLink = "~/Views/Modules/Survey/SurveyQuestionDetails.cshtml";
            public const string SurveyAddNewPageLink = "~/Views/Modules/Survey/AddNewSurvey.cshtml";

            //Ticker
            public const string TickerOverviewPageLink = "~/Views/Modules/Ticker/TickerOverview.cshtml";
            public const string TickerDetailsPageLink = "~/Views/Modules/Ticker/TickerDetails.cshtml";
            public const string TickerAddNewPageLink = "~/Views/Modules/Ticker/AddNewTicker.cshtml";

            //RSS
            public const string RssCategoryOverviewPageLink = "~/Views/Modules/RSS/RssCategoryOverview.cshtml";
            public const string RssCategoryDetailsPageLink = "~/Views/Modules/RSS/RssCategoryDetails.cshtml";
            public const string RssFeedOverviewPageLink = "~/Views/Modules/RSS/RssFeedOverview.cshtml";
            public const string RssFeedDetailsPageLink = "~/Views/Modules/RSS/RssFeedDetails.cshtml";
            public const string RSSAddNewPageLink = "~/Views/Modules/RSS/AddNewRSS.cshtml";
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
