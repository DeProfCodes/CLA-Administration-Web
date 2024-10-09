using CLA_Administration_Web.ViewModels.Shared;

namespace CLA_Administration_Web.ViewModels.Targeting
{
    public class TargetedUser
    {
        public string DomainName { get; set; }

        public string NTUsername { get; set; }

        public string DisplayName { get; set; }

        public string LastSyncDT { get; set; }

        public StatusViewModel Status { get; set; }
    }
}
