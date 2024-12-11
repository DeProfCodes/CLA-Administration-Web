using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;

namespace CLA_Administration_Web.Helpers.MockData
{
    public class SettingsMockData
    {
        public static List<StagingUserMachineViewModel> StagingUsers { get; set; } = GetStagingUsersOrMachines();

        public static List<StagingUserMachineViewModel> StagingMachines { get; set; } = GetStagingUsersOrMachines();

        public static List<SetupExclusionsUsersViewModel> SetupExcludedUsers { get; set; } = GetSetupUsersExclusions();

        public static List<SetupExclusionMachinesViewModel> SetupExcludedMachines { get; set; } = GetSetupMachinesExclusions();

        public static List<StagingUserMachineViewModel> GetStagingUsersOrMachines()
        {
            var result = new List<StagingUserMachineViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new StagingUserMachineViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                    Firstname = MockDataHelperFunctions.GetRandomFirstname(),
                    Lastname = MockDataHelperFunctions.GetRandomLastname(),
                    MachineName = MockDataHelperFunctions.GetRandomMachineID(),
                    Username = MockDataHelperFunctions.GetRandomUserID(),
                    MachineDescription = MockDataHelperFunctions.GetRandomMachineID(),
                };
                result.Add(item);
            }
            return result;
        }

        public static List<SetupExclusionMachinesViewModel> GetSetupMachinesExclusions()
        {
            var result = new List<SetupExclusionMachinesViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new SetupExclusionMachinesViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID(),
                    MachineName = MockDataHelperFunctions.GetRandomMachineID(),
                    MachineDescription = MockDataHelperFunctions.GetRandomMachineID(),
                };
                result.Add(item);
            }
            return result;
        }

        public static List<SetupExclusionsUsersViewModel> GetSetupUsersExclusions()
        {
            var result = new List<SetupExclusionsUsersViewModel>();

            var rand = new Random();

            for (int i = 0; i < 15; i++)
            {
                var item = new SetupExclusionsUsersViewModel()
                {
                    Id = rand.Next(41, 999),
                    Domain = MockDataHelperFunctions.GetRandomDomainName(),
                    Username = MockDataHelperFunctions.GetRandomUserID(),
                    Firstname = MockDataHelperFunctions.GetRandomFirstname(),
                    Lastname = MockDataHelperFunctions.GetRandomLastname(),
                    UserLastModified = MockDataHelperFunctions.GetRandomUserID(),
                    MachineLastModified = MockDataHelperFunctions.GetRandomMachineID()
                };
                result.Add(item);
            }
            return result;
        }
    }
}
