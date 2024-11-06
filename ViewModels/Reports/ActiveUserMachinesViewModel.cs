using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Models.APIResponses.Reports.ActiveUserMachine;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ActiveUserMachinesViewModel
    {
        public ReportsNamesType ReportName { get; set; }

        public List<ActiveUserReport> ActiveUserReports { get; set; }

        public List<ActiveMachineReport> ActiveMachineReports { get; set; }
    }
}
