namespace CLA_Administration_Web.ViewModels.API.Reports
{
    public class ModuleSummaryParamsViewModel
    {
        public int ModuleId { get; set; }

        public bool UseMachineId { get; set; }

        public bool ShowComplete { get; set; }

        public bool ShowOutstanding { get; set; }

        public bool ShowActive { get; set; }

        public string Environment { get; set; }

        public int Active { get; set; }

        public int Dormant { get; set; }

        public int InActive { get; set; }

        public bool ConnectToLive { get; set; }
    }
}
