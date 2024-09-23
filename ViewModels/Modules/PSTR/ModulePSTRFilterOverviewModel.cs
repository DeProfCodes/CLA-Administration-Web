using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules.PSTR
{
    /// <summary>
    /// Module View Model for the modules: Popup, Survey, Ticker, RSS (PSTR)
    /// </summary>
    public class ModulePSTRFilterOverviewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public ModulesPages ModuleDetailsPage { get; set; }

        public ModuleFilterTitle FilterTitle { get; set; }

        public List<string> ColumnNames { get; set; }

        public List<ModulePSTRDataViewModel> ModulesData { get; set; }
    }
}
