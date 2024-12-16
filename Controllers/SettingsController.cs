using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Settings;
using CLA_Administration_Web.ViewModels.Settings.ActiveConections;
using CLA_Administration_Web.ViewModels.Settings.ActiveConnections;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
using CLA_Administration_Web.ViewModels.Settings.StagingUsers;
using CLA_Administration_Web.ViewModels.Settings.Shared;
using Microsoft.AspNetCore.Mvc;
using CLA_Administration_Web.ViewModels.Targeting;
using CLA_Administration_Web.ViewModels.Settings.ManageAdminAccess;

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
        public ActionResult EditStagingMachine(int machineId, string entityType)
        {
           
            var stagingUsersData = new StagingUsersMainViewModel()
            {
                StagingUsers = SettingsMockData.StagingUsers,
                StagingMachines = SettingsMockData.StagingMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = stagingUsersData.StagingMachines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = stagingUsersData.StagingUsers.FirstOrDefault(u => u.Id == machineId);
            }

          
            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;

            return PartialView(AppPagesLinks.Settings.StagingModalViewPageLink, selectedEntity);
        }

        [HttpGet]
        public ActionResult EditSetupExclusions(int machineId, string entityType)
        {
            var setupExcludedData = new SetupExclusionsMainViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = setupExcludedData.Machines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = setupExcludedData.Users.FirstOrDefault(u => u.Id == machineId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;
            return PartialView(AppPagesLinks.Settings.SetupExclusionModalPageLink, selectedEntity);

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
        public ActionResult EditSetupExclusionss(int machineId, string entityType)
        {
            var setupExcludedData = new BaseSettingsViewModel()
            {
                Users = SettingsMockData.SetupExcludedUsers,
                Machines = SettingsMockData.SetupExcludedMachines
            };

            object selectedEntity = null;

            if (entityType == "Machine")
            {
                selectedEntity = setupExcludedData.Machines.FirstOrDefault(m => m.Id == machineId);
            }
            else if (entityType == "User")
            {
                selectedEntity = setupExcludedData.Users.FirstOrDefault(u => u.Id == machineId);
            }

            if (selectedEntity == null)
            {
                return NotFound($"{entityType} with ID {machineId} not found.");
            }

            ViewBag.EntityType = entityType;
            return PartialView(AppPagesLinks.Settings.EditSettingsModalPageLink, selectedEntity);
        }

        [HttpGet]
        public async Task<IActionResult> AdminAccess()
        {
           
          return PartialView(AppPagesLinks.Settings.AdminAccessPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TargetGroups()
        {
            var targetGroups = new TargetingExposureViewModel()
            {
                TargetedUsers = SettingsMockData.TargetGroupUsers
              
            };
            return PartialView(AppPagesLinks.Settings.TargetGroupsPageLink, targetGroups);
        }

        [HttpGet]
        public async Task<IActionResult> CustomUserSettings()
        {
            return PartialView(AppPagesLinks.Settings.CustomUserSettingsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveConnections()
        {
            
                var connections = new ActiveConnectionsMainViewModel()
                {
                    Connections = SettingsMockData.ActiveConnections,
                };
        
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
 