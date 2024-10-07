using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum ModulesPages
    {
        [Display(Name = "", ShortName = "")]
        None,

        //All Modules
        [Display(Name = "AllModules", ShortName = "")]
        AllModules,

        //PST Modules: Popup, Survey, Tikcer
        [Display(Name = "ModulePSTTableOverview", ShortName = "PST")]
        ModulePSTTableOverview,

        //LDS Modules: Lockscreen, Desktop, Screensaver
        [Display(Name = "ModuleLDSTableOverview", ShortName = "LDS")]
        ModuleLDSTableOverview,

        [Display(Name = "ModuleLDSCalendarOverview", ShortName = "LDS")]
        ModuleLDSCalendarOverview,

        [Display(Name = "ModuleLDSGanttOverview", ShortName = "LDS")]
        ModuleLDSGanttOverview,

        //Content Library
        [Display(Name = "ContentLibraryCategories", ShortName = "ContentLibrary")]
        ContentLibraryCategories,

        [Display(Name = "AddNewContentLibraryCategory", ShortName = "ContentLibrary")]
        AddNewContentLibraryCategory,

        [Display(Name = "ContentLibraryCategoryDetails", ShortName = "ContentLibrary")]
        ContentLibraryCategoryDetails,

        [Display(Name = "ContentLibraryContent", ShortName = "ContentLibrary")]
        ContentLibraryContent,

        [Display(Name = "ContentLibraryContentDetails", ShortName = "ContentLibrary")]
        ContentLibraryContentDetails,

        [Display(Name = "AddNewContentLibraryContent", ShortName = "ContentLibrary")]
        AddNewContentLibraryContent,

        //Desktop
        [Display(Name = "DesktopOverview", ShortName = "Desktop")]
        DesktopOverview,

        [Display(Name = "DesktopDetails", ShortName = "Desktop")]
        DesktopDetails,

        [Display(Name = "DesktopAddNew", ShortName = "Desktop")]
        DesktopAddNew,

        //LockedDesktop
        [Display(Name = "LockedDesktopOverview", ShortName = "LockedDesktop")]
        LockedDesktopOverview,

        [Display(Name = "LockedDesktopDetails", ShortName = "LockedDesktop")]
        LockedDesktopDetails,

        [Display(Name = "LockedDesktopAddNew", ShortName = "LockedDesktop")]
        LockedDesktopAddNew,

        //Screensaver
        [Display(Name = "ScreensaverOverview", ShortName = "Screensaver")]
        ScreensaverOverview,

        [Display(Name = "ScreensaverDetails", ShortName = "Screensaver")]
        ScreensaverDetails,

        [Display(Name = "ScreensaverAddNew", ShortName = "Screensaver")]
        ScreensaverAddNew,

        //Popups
        [Display(Name = "PopupOverview", ShortName = "Popup")]
        PopupOverview,

        [Display(Name = "PopupDetails", ShortName = "Popup")]
        PopupDetails,

        [Display(Name = "AddNewPopup", ShortName = "Popup")]
        PopupAddNew,

        //Ticker
        [Display(Name = "TickerOverview", ShortName = "Ticker")]
        TickerOverview,

        [Display(Name = "TickerDetails", ShortName = "Ticker")]
        TickerDetails,

        [Display(Name = "AddNewTicker", ShortName = "Ticker")]
        TickerAddNew,

        //Survey
        [Display(Name = "SurveyOverview", ShortName = "Survey")]
        SurveyOverview,

        [Display(Name = "SurveyDetails", ShortName = "Survey")]
        SurveyDetails,

        [Display(Name = "SurveyQuestionsOverview", ShortName = "Survey")]
        SurveyQuestionsOverview,

        [Display(Name = "SurveyQuestionDetails", ShortName = "Survey")]
        SurveyQuestionDetails,

        [Display(Name = "AddNewSurvey", ShortName = "Survey")]
        SurveyAddNew,

        //RSS
        [Display(Name = "RssCategoryOverview", ShortName = "RSS")]
        RSSCategoryOverview,

        [Display(Name = "RssCategoryDetails", ShortName = "RSS")]
        RSSCategoryDetails,

        [Display(Name = "RssFeedOverview", ShortName = "RSS")]
        RSSFeedOverview,

        [Display(Name = "RssFeedDetails", ShortName = "RSS")]
        RSSFeedDetails,

        [Display(Name = "RSSAddNewCategory", ShortName = "RSS")]
        RSSAddNewCategory,

        [Display(Name = "AddNewRSSFeed", ShortName = "RSS")]
        RSSAddNewFeed,

        [Display(Name = "ModuleContentPreviewer", ShortName = "Component")]
        ModuleContentPreviewer,

    }
}
