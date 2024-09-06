using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Dashboard
{
    public enum ModulesPages
    {
        [Display(Name = "")]
        None,

        //Content Library
        [Display(Name = "ContentLibraryCategories")]
        ContentLibraryCategories,

        [Display(Name = "ContentLibraryContent")]
        ContentLibraryContent,

        //Desktop
        [Display(Name = "DesktopOverview")]
        DesktopOverview,

        [Display(Name = "DesktopAddNew")]
        DesktopAddNew,

        //LockedDesktop
        [Display(Name = "LockedDesktopOverview")]
        LockedDesktopOverview,

        [Display(Name = "LockedDesktopAddNew")]
        LockedDesktopAddNew,

        //Screensaver
        [Display(Name = "ScreensaverOverview")]
        ScreensaverOverview,

        [Display(Name = "ScreensaverAddNew")]
        ScreensaverAddNew,

        //Popups
        [Display(Name = "PopupOverview")]
        PopupOverview,

        [Display(Name = "PopupAddNew")]
        PopupAddNew,

        //Ticker
        [Display(Name = "TickerOverview")]
        TickerOverview,

        [Display(Name = "TickerAddNew")]
        TickerAddNew,

        //Survey
        [Display(Name = "SurveyOverview")]
        SurveyOverview,

        [Display(Name = "SurveyAddNew")]
        SurveyAddNew,

        //RSS
        [Display(Name = "RSSOverview")]
        RSSOverview,

        [Display(Name = "RSSAddNew")]
        RSSAddNew
    }
}
