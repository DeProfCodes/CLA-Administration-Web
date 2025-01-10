using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Targeting;

namespace CLA_Administration_Web.ViewModels.Settings.SetupExclusion
{
    public class SetupExclusionsMainViewModel
    {
        public List<SetupExclusionsUsersViewModel> Users { get; set; }

        public List<SetupExclusionMachinesViewModel> Machines { get; set; }

        public ModuleNamesType ModuleName { get; set; }

        public List<TargetedEntityTree> TargetedEntities { get; set; }

        public List<TargetedEntityTree> TargetedAccepted { get; set; }

        public List<TargetedEntityTree> TargetedGroups { get; set; }

        public bool IsReadonly { get; set; }
    }
}
