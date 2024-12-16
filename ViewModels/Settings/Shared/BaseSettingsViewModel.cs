using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;

namespace CLA_Administration_Web.ViewModels.Settings.Shared
{
    public class BaseSettingsViewModel
    {  
 
        public List<SetupExclusionsUsersViewModel> Users { get; set; }
        public List<SetupExclusionMachinesViewModel> Machines { get; set; }
        public List<StagingUserMachineViewModel> StagingUsers { get; set; }
        public List<StagingUserMachineViewModel> StagingMachines { get; set; }
    }
}
