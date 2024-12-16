using CLA_Administration_Web.Helpers.Enums.AppPages;

namespace CLA_Administration_Web.ViewModels.Modules.PST
{
    /// <summary>
    /// Module Overview Filter View Model for the modules: Popup, Survey, Ticker (PST)
    /// </summary>
    public class ModulePSTOverviewFilterViewModel
    {
        public ModulesPages ModulePage { get; set; }

        public List<string> Usernames { get; set; }
    }
}
