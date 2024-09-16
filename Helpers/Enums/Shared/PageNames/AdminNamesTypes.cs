using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared.PageNames
{
    public enum AdminNamesTypes
    {
        [Display(Name = "", Description = "")]
        None,

        [Display(Name = "UploadFiles", Description = "Upload Files")]
        UploadFiles,

        [Display(Name = "ApplicationParameters", Description = "Application Parameters")]
        ApplicationParameters,

        [Display(Name = "Licensing", Description = "Licensing")]
        Licensing,

        [Display(Name = "AutoReminders", Description = "Auto Reminders")]
        AutoReminders,

        [Display(Name = "SQLBrowser", Description = "SQL Browser")]
        SQLBrowser
    }
}
