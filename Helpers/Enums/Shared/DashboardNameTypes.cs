using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum DashboardNameTypes
    {
        [Display(Name = "", Description = "")]
        None,

        [Display(Name = "Dashboard", Description = "Home")]
        Dashboard,

        [Display(Name = "Calendar", Description = "Calendar")]
        Calendar,

    }
}
