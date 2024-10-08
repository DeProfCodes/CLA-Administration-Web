using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;

namespace CLA_Administration_Web.ViewModels.Targeting
{
    public class TargetedEntityViewModel
    {
        public ModuleNamesType ModuleName { get; set; }

        public List<TargetedEntityTree> TargetedEntities { get; set; }

        public List<TargetedEntityTree> TargetedAccepted { get; set; }

        public List<TargetedEntityTree> TargetedGroups { get; set; }

    }
}
