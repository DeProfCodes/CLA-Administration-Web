using Microsoft.Reporting.NETCore;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ReportModuleViewModel
    {
        public PopupReportsRaw PopupReportData { get; set; }

        public TickerReportsRaw TickerReportData { get; set; }

        public SurveyReportsRaw SurveyReportData {get; set; }
    }
}
