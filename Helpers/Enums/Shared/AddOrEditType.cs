using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum AddOrEditType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Add")]
        Add,

        [Display(Name = "Edit")]
        Edit,
    }
}
