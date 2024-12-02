using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum SettingsPages
    {
        [Display(Name = "", Description = "")]
        None,

        [Display(Name = "AllSettings", Description = "All Settings")]
        AllSettings,

        [Display(Name = "StagingUsers", Description = "Staging Users")]
        StagingUsers,

        [Display(Name = "AddNewStagingUser", Description = "Add New Staging User")]
        AddNewStagingUser,

        [Display(Name = "SetupExclusions", Description = "Setup Exclusions")]
        SetupExclusions,

        [Display(Name = "AdminAccess", Description = "Admin Access")]
        AdminAccess,

        [Display(Name = "TargetGroups", Description = "Target Groups")]
        TargetGroups,

        [Display(Name = "CustomUserSettings", Description = "Custom User Settings")]
        CustomUserSettings,

        [Display(Name = "ActiveConnections", Description = "Active Connections")]
        ActiveConnections,

        [Display(Name = "SkinsOfflineImages", Description = "Skins And Offline Images")]
        SkinsOfflineImages,

        [Display(Name = "DefaultFonts", Description = "Default Fonts")]
        DefaultFonts,

        [Display(Name = "DesktopInformation", Description = "Desktop Information")]
        DesktopInformation
    }
}
