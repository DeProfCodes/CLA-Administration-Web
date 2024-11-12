using CLA_Administration_Web.Models.APIResponses.Reports.Policy;

namespace CLA_Administration_Web.ViewModels.Reports.Policy
{
    public class PolicyReportSummaryViewModel
    {
        public PolicyReportSummary SummaryUsers { get; set; }

        public PolicyReportSummary SummaryMachines { get; set; }

        public List<PolicyReportSummarizedDetail> SummarizedDetailsUsers { get; set; }

        public List<PolicyReportSummarizedDetail> SummarizedDetailsMachines { get; set; }
    }
}
