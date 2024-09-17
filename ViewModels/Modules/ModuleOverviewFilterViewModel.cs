using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules
{
    public class ModuleOverviewFilterViewModel
    {
        public ModulesPages ModulePage { get; set; }

        public List<string> Usernames { get; set; }
    }
}
