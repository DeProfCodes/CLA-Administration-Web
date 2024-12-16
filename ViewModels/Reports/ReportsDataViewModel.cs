using CLA_Administration_Web.ViewModels.Reports.Policy;
using CLA_Administration_Web.ViewModels.Reports.Survey;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ReportsDataViewModel
    {
        public PopupReportsViewModel PopupReportsData { get; set; }

        public SurveyReportViewModel SurveyReportsData { get; set; }

        public TickerReportsViewModel TickersReportsData { get; set; }

        public PolicyReportViewModel PolicyReportsData { get; set; }

    }
}
