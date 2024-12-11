using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.ViewModels.Settings;
using CLA_Administration_Web.ViewModels.Settings.ActiveConections;
using CLA_Administration_Web.ViewModels.Settings.ActiveConnections;
using CLA_Administration_Web.ViewModels.Settings.SetupExclusion;
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
 