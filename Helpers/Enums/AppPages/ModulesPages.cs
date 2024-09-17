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

        [Display(Name = "_FilterPopupsOverview", ShortName = "Popup")]
        PopupOverviewFilter,

        [Display(Name = "AddNewPopup", ShortName = "Popup")]
        PopupAddNew,

        //Ticker
        [Display(Name = "TickerOverview", ShortName = "Ticker")]
        TickerOverview,

        [Display(Name = "TickerAddNew", ShortName = "Ticker")]
        TickerAddNew,

        //Survey
        [Display(Name = "SurveyOverview", ShortName = "Survey")]
        SurveyOverview,

        [Display(Name = "SurveyAddNew", ShortName = "Survey")]
        SurveyAddNew,

        //RSS
        [Display(Name = "RSSOverview", ShortName = "RSS")]
        RSSOverview,

        [Display(Name = "RSSAddNew", ShortName = "RSS")]
        RSSAddNew
    }
}
