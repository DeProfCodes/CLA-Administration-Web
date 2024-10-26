namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ModuleReportDataFilterViewModel
    {
        public int ModuleId { get; set; }

        public bool ShowRawDataOnly { get; set; }

        public int Active { get; set; }

        public int InActive { get; set; }

        public int NotInstalled { get; set; }
    }
}
