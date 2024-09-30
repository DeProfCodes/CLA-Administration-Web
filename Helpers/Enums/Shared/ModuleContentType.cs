using System.ComponentModel.DataAnnotations;

namespace CLA_Administration_Web.Helpers.Enums.Shared
{
    public enum ModuleContentType
    {
        [Display(Name = "")]
        None,

        [Display(Name = "Picture")]
        Picture,

        [Display(Name = "Video")]
        Video,

        [Display(Name = "Audio")]
        Audio,

        [Display(Name = "Website")]
        Website,

        [Display(Name = "Document")]
        Document,
    }
}
