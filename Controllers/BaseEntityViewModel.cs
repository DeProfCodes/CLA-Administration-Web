using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;

namespace CLA_Administration_Web.Controllers
{
    internal class BaseEntityViewModel
    {
        public BaseEntityViewModel()
        {
        }
        public List<SetupExclusionsUsersViewModel> Users { get; set; }
        public List<SetupExclusionMachinesViewModel> Machines { get; set; }
        public List<StagingUserMachineViewModel> StagingUsers { get; set; }
        public List<StagingUserMachineViewModel> StagingMachines { get; set; }
    }
}