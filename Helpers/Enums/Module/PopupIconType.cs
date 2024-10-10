using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Module
{
    public enum PopupIconType
    {
        [Display(Name = "", ShortName = "")]
        None,

        [Display(Name = "Information", ShortName = "icon-info.png")]
        Information = 1,

        [Display(Name = "Warning", ShortName = "icon-warning.png")]
        Warning = 2,

        [Display(Name = "Error", ShortName = "icon-error.png")]
        Error = 3,
    }
}
