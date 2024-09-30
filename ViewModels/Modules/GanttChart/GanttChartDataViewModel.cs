using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.LDS;

namespace CLA_Administration_Web.ViewModels.Modules.GanttChart
{
    public class GanttChartDataViewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public ModuleFilterTitle FilterTitle { get; set; }

        public List<GanttChartDataModel> GanttData { get; set; }

        public int GanttChartHeight { get; set; }

        public List<GanttChartToolTipViewModel> GanttChartToolTip { get; set; }
    }
}
