using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Reports
{
    public enum PolicyReportEntityType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Users")]
        Users,

        [Display(Name = "Machines")]
        Machines,

        [Display(Name = "UsersAndMachines")]
        UsersAndMachines,
    }
}
