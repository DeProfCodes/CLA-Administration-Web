namespace CLA_Administration_Web.ViewModels.API.Reports
{
    public class ModuleSummaryParamsViewModel
    {
        public required int ModuleId { get; set; }

        public required bool UseMachineId { get; set; }

        public required bool ShowComplete { get; set; }

        public required bool ShowOutstanding { get; set; }

        public required bool ShowActive { get; set; }

        public required string Environment { get; set; }

        public required int Active { get; set; }

        public required int Dormant { get; set; }

        public required int InActive { get; set; }

        public required bool ConnectToLive { get; set; }
    }
}
