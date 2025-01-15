using CLA_Administration_Web.ViewModels.Targeting;

namespace CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess
{
    public class ManageAdminAccessMainViewModel
    {
        public List<AdminAccessItem> AdminAccessItems { get; set; }
        public List<TargetedEntityTree> TargetedEntities { get; set; }

        public List<TargetedEntityTree> TargetedAccepted { get; set; }

        public List<TargetedEntityTree> TargetedGroups { get; set; }
    }
}
