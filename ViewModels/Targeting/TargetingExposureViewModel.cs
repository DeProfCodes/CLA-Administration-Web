namespace CLA_Administration_Web.ViewModels.Targeting
{
    public class TargetingExposureViewModel
    {
        public List<TargetedGroup> TargetedGroups { get; set; }

        public List<TargetedUser> TargetedUsers { get; set; }

        public List<TargetedMachine> TargetedMachines { get; set; }

        public  List<TargetedIPRange> TargetedIPRanges { get; set; }


        public List<TargetedEntityTree> TargetedEntities { get; set; }

        public List<TargetedEntityTree> TargetedAccepted { get; set; }


    }
}
