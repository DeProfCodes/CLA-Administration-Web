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

        public class Targeting
        {
            public const string TargetedEntityPSTPageLink = "~/Views/Shared/Components/Custom/Modules/Targeting/TargetedEntityPST.cshtml";
            public const string TargetingExposurePageLink = "~/Views/Shared/Components/Custom/Modules/Targeting/TargetingExposure.cshtml";
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

            //PST Modules: Popup, Survey, Ticker
            public const string ModulePSTTableOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/PST/ModulePSTTableOverview.cshtml";
            
            //LDS Modules: Lockscreen, Desktop, Screensaver 
            public const string ModuleLDSTableOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSTableOverview.cshtml";
            public const string ModuleLDSGanttOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSGanttOverview.cshtml";
            public const string ModuleLDSCalendarOverviewPageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/ModuleLDSCalendarOverview.cshtml";
            public const string AddNewLDSModulePageLink = "~/Views/Shared/Components/Custom/Modules/Overviews/LDS/AddNewLDSModule.cshtml";

            //Content Library
            public const string ContentLibraryCategoriesPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryCategories.cshtml";
            public const string ContentLibraryCategoryDetailsPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryCategoryDetails.cshtml";
            public const string AddNewContentLibraryCategoryPageLink = "~/Views/Modules/ContentLibrary/AddNewContentLibraryCategory.cshtml";
            public const string ContentLibraryContentsPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryContentsOverview.cshtml";
            public const string ContentLibraryContentDetailsPageLink = "~/Views/Modules/ContentLibrary/ContentLibraryContentDetails.cshtml";
            public const string AddNewContentLibraryContentPageLink = "~/Views/Modules/ContentLibrary/AddNewContentLibraryContent.cshtml";

            //Desktop
            public const string DesktopOverviewPageLink = "~/Views/Modules/Desktop/DesktopOverview.cshtml";
            public const string DesktopDetailsPageLink = "~/Views/Modules/Desktop/DesktopDetails.cshtml";
            public const string DesktopAddNewPageLink = "~/Views/Modules/Desktop/AddNewDesktop.cshtml";

            //Locked Desktop
            public const string LockedDesktopOverviewPageLink = "~/Views/Modules/LockedDesktop/LockedDesktopOverview.cshtml";
            public const string LockedDesktopDetailsPageLink = "~/Views/Modules/LockedDesktop/LockedDesktopDetails.cshtml";
            public const string LockedDesktopAddNewPageLink = "~/Views/Modules/LockedDesktop/AddNewLockedDesktop.cshtml";

            //Screensaver
            public const string ScreensaverOverviewPageLink = "~/Views/Modules/Screensaver/ScreensaverOverview.cshtml";
            public const string ScreensaverDetailsPageLink = "~/Views/Modules/Screensaver/ScreensaverDetails.cshtml";
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
            public const string AddNewSurveyQuestionPageLink = "~/Views/Modules/Survey/AddNewSurveyQuestion.cshtml";

            //Ticker
            public const string TickerOverviewPageLink = "~/Views/Modules/Ticker/TickerOverview.cshtml";
            public const string TickerDetailsPageLink = "~/Views/Modules/Ticker/TickerDetails.cshtml";
            public const string TickerAddNewPageLink = "~/Views/Modules/Ticker/AddNewTicker.cshtml";

            //RSS
            public const string RssCategoryOverviewPageLink = "~/Views/Modules/RSS/RssCategoryOverview.cshtml";
            public const string RssCategoryDetailsPageLink = "~/Views/Modules/RSS/RssCategoryDetails.cshtml";
            public const string RssFeedOverviewPageLink = "~/Views/Modules/RSS/RssFeedOverview.cshtml";
            public const string RssFeedDetailsPageLink = "~/Views/Modules/RSS/RssFeedDetails.cshtml";
            public const string RSSAddNewCategoryPageLink = "~/Views/Modules/RSS/AddNewRSSCategory.cshtml";
            public const string RSSAddNewFeedPageLink = "~/Views/Modules/RSS/AddNewRSSFeed.cshtml";

            //Previewer Components
            public const string ModuleImagePreviewerPageLink = "~/Views/Shared/Components/Custom/Modules/ContentPreviewers/ImagePreviewer.cshtml";
            public const string ModuleAudioPreviewerPageLink = "~/Views/Shared/Components/Custom/Modules/ContentPreviewers/AudioPreviewer.cshtml";
            public const string ModuleVideoPreviewerPageLink = "~/Views/Shared/Components/Custom/Modules/ContentPreviewers/VideoPreviewer.cshtml";
            public const string ModuleDocumentPreviewerPageLink = "~/Views/Shared/Components/Custom/Modules/ContentPreviewers/DocumentPreviewer.cshtml";
        }

        public class Settings
        {
            public const string StagingUsersPageLink = "~/Views/Settings/StagingUsers.cshtml";
            public const string SetupExclusionsPageLink = "~/Views/Settings/SetupExclusions.cshtml";
            public const string AdminAccessPageLink = "~/Views/Settings/AdminAccess.cshtml";
            
            public const string ActiveConnectionsPageLink = "~/Views/Settings/ActiveConnections.cshtml";
           
            public const string DesktopInformationPageLink = "~/Views/Settings/DesktopInformation.cshtml";

            //Target group
            public const string TargetGroupsPageLink = "~/Views/Settings/TargetGroups.cshtml";


            //Default fonts
            public const string DefaultFontsPageLink = "~/Views/Settings/DefaultFonts.cshtml";
            public const string DefaultFontsDetailsPageLink = "~/Views/Settings/DefaultFonts/DefaultFontsDetails.cshtml";

            //custom user settings
            public const string CustomUserSettingsDetailsPageLink = "~/Views/Settings/CustomUser/CustomUserSettingsDetails.cshtml";
            public const string CustomUserSettingsPageLink = "~/Views/Settings/CustomUserSettings.cshtml";

            //Skins and Offline
            public const string SkinsOfflineImagesPageLink = "~/Views/Settings/SkinsOfflineImages.cshtml";
            public const string SkinsOfflineImagesDetailsPageLink = "~/Views/Settings/SkinsOfflineImage/SkinsAndOfflineImageDetails.cshtml";


            //Modal setting component
            public const string EditAdminModalPageLink = "~/Views/Shared/Components/Custom/Settings/SettingsModal/AdminAccessViewModalComponent.cshtml";
            public const string SetupExclusionModalPageLink = "~/Views/Shared/Components/Custom/Settings/SettingsModal/SetupExclusionModalView.cshtml";
            public const string StagingModalViewPageLink = "~/Views/Shared/Components/Custom/Settings/SettingsModal/StagingModalView.cshtml";
            public const string AdminAccessModalPageLink = "~/Views/Shared/Components/Custom/Settings/SettingsModal/StagingModalView.cshtml";
            public const string TargeGroupEditModal = "~/Views/Shared/Components/Custom/Settings/SettingsModal/TargetGroupEditModal.cshtml";

        }

        public class Reports
        {
            public const string ModuleRawDataPageLink = "~/Views/Shared/Components/Custom/Reports/ModuleReportRawData.cshtml";
            public const string SurveyPageLink = "~/Views/Reports/Survey/SurveyReport.cshtml";
            public const string SurveyReportOnlyPageLink = "~/Views/Reports/Survey/_SurveyReportOnly.cshtml";
            public const string PopupPageLink = "~/Views/Reports/Popup/PopupReport.cshtml";
            public const string PopupReportOnlyPageLink = "~/Views/Reports/Popup/_PopupReportOnly.cshtml";
            public const string TickerPageLink = "~/Views/Reports/Ticker/TickerReport.cshtml";
            public const string TickerReportOnlyPageLink = "~/Views/Reports/Ticker/_TickerReportDataOnly.cshtml";
            public const string PolicyPageLink = "~/Views/Reports/Policy/PolicyReport.cshtml";
            public const string PolicyReportOnlyPageLink = "~/Views/Reports/Policy/_PolicyReportOnly.cshtml";
            public const string PolicyReportRawDataPageLink = "~/Views/Reports/Policy/_PolicyReportRawDetails.cshtml";
            public const string ActiveUsersPageLink = "~/Views/Reports/ActiveUsersMachines/ActiveUsersReport.cshtml";
            public const string ActiveMachinesPageLink = "~/Views/Reports/ActiveUsersMachines/ActiveMachinesReport.cshtml";
            public const string ActiveUserMachineTablePageLink = "~/Views/Reports/ActiveUsersMachines/_ActiveUserMachineTable.cshtml";
            public const string CampaignDispatchPageLink = "~/Views/Reports/CampaignDispatch/CampaignDispatchReport.cshtml";
            public const string CampaignDispatchListPageLink = "~/Views/Reports/CampaignDispatch/_CampaignDispatchList.cshtml";
            public const string TroubleshootPageLink = "~/Views/Reports/Troubleshoot/TroubleshootReport.cshtml";
            public const string TroubleshootDataPageLink = "~/Views/Reports/Troubleshoot/_TroubleshootReportData.cshtml";
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
