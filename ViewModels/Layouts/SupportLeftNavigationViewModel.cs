using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.ViewModels.Layouts
{
    public class SupportLeftNavigationViewModel
    {
        public SupportNamesType SupportName { get; set; }

        public SupportPages SupportPage { get; set; }

        public string IconWhiteUrl { get; set; }

        public string IconBlueUrl { get; set; }
    }
}
