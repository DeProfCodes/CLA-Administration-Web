using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum StatusType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "All")]
        All,

        [Display(Name = "Active")]
        Active,

        [Display(Name = "Expired")]
        Expired,

        [Display(Name = "Pending")]
        Pending
    }
}
