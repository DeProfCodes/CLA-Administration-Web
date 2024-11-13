using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum CLAEntityType
    {
        [Display(Name = "", Description = "")]
        None,

        [Display(Name = "User", Description = "User")]
        User,

        [Display(Name = "Machine", Description = "Machine")]
        Machine,

        [Display(Name = "Group", Description = "Group")]
        Group,

        [Display(Name = "IPAddress", Description = "IP Address")]
        IPAddress
    }
}
