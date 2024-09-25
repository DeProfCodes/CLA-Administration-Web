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

        //PSTR Modules: Popup, Survey, Tikcer, RSS
        [Display(Name = "ModulePSTRTableOverview", ShortName = "PSTR")]
        ModulePSTRTableOverview,

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

        [Display(Name = "ContentLibraryContent", ShortName = "ContentLibrary")]
        ContentLibraryContent,

        //Desktop
        [Display(Name = "DesktopOverview", ShortName = "Desktop")]
        DesktopOverview,

        [Display(Name = "DesktopAddNew", ShortName = "Desktop")]
        DesktopAddNew,

        //LockedDesktop
        [Display(Name = "LockedDesktopOverview", ShortName = "LockedDesktop")]
        LockedDesktopOverview,

        [Display(Name = "LockedDesktopAddNew", ShortName = "LockedDesktop")]
        LockedDesktopAddNew,

        //Screensaver
        [Display(Name = "ScreensaverOverview", ShortName = "Screensaver")]
        ScreensaverOverview,

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

        [Display(Name = "RSSAddNew", ShortName = "RSS")]
        RSSAddNew
    }
}
