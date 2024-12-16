using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.Shared;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class SettingsController : Controller
    {
        private readonly ILogger<SettingsController> _logger;

        public SettingsController(ILogger<SettingsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> StagingUsers()
        {
            var stagingUsersData = new StagingUsersMainViewModel()
            {
                StagingUsers = SettingsMockData.StagingUsers,
                StagingMachines = SettingsMockData.StagingMachines
            };

            return PartialView(AppPagesLinks.Settings.StagingUsersPageLink, stagingUsersData);
        }


        [HttpGet]
        public ActionResult EditStagingMachine(int machineId)
        {

            var stagingMachines = SettingsMockData.StagingMachines;

            var machine = stagingMachines.FirstOrDefault(m => m.Id == machineId);

            if (machine == null)
            {
                return NotFound("Machine not found.");
            }

            return PartialView(AppPagesLinks.Settings.EditSettingsModalPageLink, machine);
        }


        [HttpPost]
        public ActionResult UpdateStagingMachine(StagingUserMachineViewModel updatedMachine)
        {

            var machine = LocalDataStorage.StagingData.SingleStagingMachine.FirstOrDefault(m => m.Id == updatedMachine.Id);


            machine.MachineName = updatedMachine.MachineName;
            machine.MachineDescription = updatedMachine.MachineDescription;
            machine.UserLastModified = updatedMachine.UserLastModified;
            machine.MachineLastModified = updatedMachine.MachineLastModified;


            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> EditEntity(string entityType, int entityId)
        {
            SettingsModalView modalViewModel;

            if (entityType == "Machine")
            {
                var machine = SettingsMockData.StagingMachines.FirstOrDefault(m => m.Id == entityId);
                if (machine == null)
                {
                    return NotFound("Machine not found.");
                }

                modalViewModel = new SettingsModalView
                {
                    ModalTitle = "Edit Staging Machine",
                    ActionButtonText = "Save Machine",
                    ActionButtonCallbackFunction = "SaveMachineChanges()",
                    EntityType = "Machine",
                    FormFields = new List<FormField>
                        {
                            new FormField { Name = "MachineId", Label = "Machine ID", Value = machine.Id.ToString() },
                            new FormField { Name = "MachineName", Label = "Machine Name", Value = machine.MachineName },
                            new FormField { Name = "MachineDescription", Label = "Machine Description", Value = machine.MachineDescription },
                            new FormField { Name = "UserLastModified", Label = "User Last Modified", Value = machine.UserLastModified },
                            new FormField { Name = "MachineLastModified", Label = "Machine Last Modified", Value = machine.MachineLastModified }
                        }
                };
            }
            else if (entityType == "User")
            {
                var user = SettingsMockData.StagingUsers.FirstOrDefault(u => u.Id == entityId);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                modalViewModel = new SettingsModalView
                {
                    ModalTitle = "Edit Staging User",
                    ActionButtonText = "Save User",
                    ActionButtonCallbackFunction = "SaveUserChanges()",
                    EntityType = "User",
                    FormFields = new List<FormField>
            {
                new FormField { Name = "UserId", Label = "User ID", Value = user.Id.ToString() },
                new FormField { Name = "UserName", Label = "User Name", Value = user.Firstname },
                new FormField { Name = "UserEmail", Label = "Email", Value = user.Domain },
                new FormField { Name = "UserRole", Label = "Role", Value = user.MachineName }
            }
                };
            }
            else
            {
                return BadRequest("Invalid entity type.");
            }

            return PartialView(AppPagesLinks.Settings.EditSettingsModalPageLink, modalViewModel);
        }


        [HttpGet]
        public async Task<IActionResult> SetupExclusions()
        {
            var setupExcludedData = new SetupExclusionsMainViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
            };

            return PartialView(AppPagesLinks.Settings.SetupExclusionsPageLink, setupExcludedData);
        }

        [HttpGet]
        public async Task<IActionResult> AdminAccess()
        {
            return PartialView(AppPagesLinks.Settings.AdminAccessPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TargetGroups()
        {
            return PartialView(AppPagesLinks.Settings.TargetGroupsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> CustomUserSettings()
        {
            return PartialView(AppPagesLinks.Settings.CustomUserSettingsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveConnections()
        {
            return PartialView(AppPagesLinks.Settings.ActiveConnectionsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SkinsOfflineImages()
        {
            return PartialView(AppPagesLinks.Settings.SkinsOfflineImagesPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> DesktopInformation()
        {
            return PartialView(AppPagesLinks.Settings.DesktopInformationPageLink);
        }
    }
}
