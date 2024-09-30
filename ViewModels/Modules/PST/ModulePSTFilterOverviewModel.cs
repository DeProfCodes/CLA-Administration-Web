using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules.PST
{
    /// <summary>
    /// Module View Model for the modules: Popup, Survey, Ticker (PST)
    /// </summary>
    public class ModulePSTFilterOverviewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public ModulesPages ModuleDetailsPage { get; set; }

        public ModuleFilterTitle FilterTitle { get; set; }

        public List<string> ColumnNames { get; set; }

        public List<ModulePSTDataViewModel> ModulesData { get; set; }
    }
}
