using CLA_Administration_Web.Helpers.Constants;
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
            return PartialView(AppPagesLinks.Settings.StagingUsersPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SetupExclusions()
        {
            return PartialView(AppPagesLinks.Settings.SetupExclusionsPageLink);
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
 