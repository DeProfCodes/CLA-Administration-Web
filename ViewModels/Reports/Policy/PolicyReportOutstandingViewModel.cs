using CLA_Administration_Web.Models.APIResponses.Reports.Policy;

namespace CLA_Administration_Web.ViewModels.Reports.Policy
{
    public class PolicyReportOutstandingViewModel
    {
        public List<PolicyReportOutstanding> PolicyOutstandingUsers { get; set; }

        public List<PolicyReportOutstanding> PolicyOutstandingMachines { get; set; }

        public List<PolicyReportOutstanding> PolicyOutstandingUserMachines { get; set; }

        public List<PolicyReportOutstanding> PolicyOutstandingSelected { get; set; }
    }
}
