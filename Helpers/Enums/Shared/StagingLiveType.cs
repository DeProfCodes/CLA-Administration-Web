using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum StagingLiveType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Staging")]
        Staging,

        [Display(Name = "Live")]
        Live,
    }
}
