using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum ModuleNamesType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "ContentLibrary")]
        ContentLibrary,

        [Display(Name = "LockedDesktop")]
        LockedDesktop,

        [Display(Name = "Desktop")]
        Desktop,

        [Display(Name = "Screensaver")]
        Screensaver,

        [Display(Name = "Popup")]
        Popup,

        [Display(Name = "Survey")]
        Survey,

        [Display(Name = "Ticker")]
        Ticker,

        [Display(Name = "RSS")]
        RSS,
    }
}
