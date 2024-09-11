using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum SettingsPages
    {
        [Display(Name = "")]
        None,

        [Display(Name = "StagingUsers")]
        StagingUsers,

        [Display(Name = "SetupExclusions")]
        SetupExclusions,

        [Display(Name = "AdminAccess")]
        AdminAccess,

        [Display(Name = "TargetGroups")]
        TargetGroups,

        [Display(Name = "CustomUserSettings")]
        CustomUserSettings,

        [Display(Name = "ActiveConnections")]
        ActiveConnections,

        [Display(Name = "SkinsOfflineImages")]
        SkinsOfflineImages,

        [Display(Name = "DefaultFonts")]
        DefaultFonts,

        [Display(Name = "DesktopInformation")]
        DesktopInformation
    }
}
