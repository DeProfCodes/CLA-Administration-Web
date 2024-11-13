using CLA_Administration_Web.Models.APIResponses.Reports.Troubleshoot;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class TroubleshootReportViewModel
    {
        public bool ConnectedToLive { get; set; }

        public bool IsBlank { get; set; }

        public TroubleshootReportLastSyncDetails LastSyncDetails { get; set; }

        public List<TroubleshootReportUserGroup> UserGroups { get; set; }

        public List<TroubleshootReportTargeting> Targeting { get; set; }

        public TroubleshootReportSettings Settings { get; set; }

    }
}
