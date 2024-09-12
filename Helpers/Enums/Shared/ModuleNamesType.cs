using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum ModuleNamesType
    {
        [Display(Name = "", Description = "")]
        None,

        [Display(Name = "ContentLibrary", Description = "Content Library")]
        ContentLibrary,

        [Display(Name = "LockedDesktop", Description = "Locked Desktop")]
        LockedDesktop,

        [Display(Name = "Desktop", Description = "Desktop")]
        Desktop,

        [Display(Name = "Screensaver", Description = "Screensaver")]
        Screensaver,

        [Display(Name = "Popup", Description = "Popup")]
        Popup,

        [Display(Name = "Survey", Description = "Survey")]
        Survey,

        [Display(Name = "Ticker", Description = "Ticker")]
        Ticker,

        [Display(Name = "RSS", Description = "RSS")]
        RSS,
    }
}
