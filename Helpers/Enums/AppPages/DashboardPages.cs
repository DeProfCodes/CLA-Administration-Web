using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.AppPages
{
    public enum DashboardPages
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Dashboard")]
        Dashboard,

        [Display(Name = "Calendar")]
        Calendar,

    }
}
