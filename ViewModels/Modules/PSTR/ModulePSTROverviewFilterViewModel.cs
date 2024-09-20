using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules.PSTR
{
    /// <summary>
    /// Module Overview Filter View Model for the modules: Popup, Survey, Ticker, RSS (PSTR)
    /// </summary>
    public class ModulePSTROverviewFilterViewModel
    {
        public ModulesPages ModulePage { get; set; }

        public List<string> Usernames { get; set; }
    }
}
