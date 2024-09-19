using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Modules
{
    public class ModuleFilterOverviewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public ModulesPages ModuleDetailsPage { get; set; }

        public string FilterTitle { get; set; }

        public List<string> ColumnNames { get; set; }
    
        public List<ModuleDataViewModel> ModulesData { get; set; }
    }
}
