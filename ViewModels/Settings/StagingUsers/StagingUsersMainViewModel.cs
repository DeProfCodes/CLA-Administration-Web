using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Targeting;

namespace CLA_Administration_Web.ViewModels.Settings.StagingUsers
{
    public class StagingUsersMainViewModel
    {
        public List<StagingUserMachineViewModel> StagingUsers { get; set; }

        public List<StagingUserMachineViewModel> StagingMachines { get; set; }

        public ModuleNamesType ModuleName { get; set; }

        public List<TargetedEntityTree> TargetedEntities { get; set; }

        public List<TargetedEntityTree> TargetedAccepted { get; set; }

        public List<TargetedEntityTree> TargetedGroups { get; set; }

        public bool IsReadonly { get; set; }
    }
}
