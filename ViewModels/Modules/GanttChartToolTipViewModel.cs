namespace CLA_Administration_Web.ViewModels.Modules
{
    public class GanttChartToolTipViewModel
    {
        public KeyVal Property1 { get; set; }

        public KeyVal Property2 { get; set; }

        public KeyVal Property3 { get; set; }

        public KeyVal Property4 { get; set; }
    }

    public class KeyVal
    {
        public string ColumnName { get; set; }

        public string ColumnValue { get; set; }
    }
}
