using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules.LDS
{
    /// <summary>
    /// Module Overview Filter View Model for the modules: Lockscreen, Desktop, Screensaver (LDS)
    /// </summary>
    public class ModuleLDSOverviewFilterViewModel
    {
        public ModulesPages ModulePage { get; set; }

        public List<DateTime> MonthsAndYears { get; set; }
    }
}
