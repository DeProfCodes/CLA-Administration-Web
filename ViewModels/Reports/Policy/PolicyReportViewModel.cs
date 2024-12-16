namespace CLA_Administration_Web.ViewModels.Reports.Policy
{
    public class PolicyReportViewModel
    {
        public int PopupId { get; set; }

        public PolicyReportSummaryViewModel PolicySummary { get; set; }

        public PolicyReportOutstandingViewModel PolicyOutstanding { get; set; }
    }
}
