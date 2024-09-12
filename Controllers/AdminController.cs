using CLA_Administration_Web.Helpers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> UploadFiles()
        {
            return PartialView(AppPagesLinks.Admin.UploadFilesPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationParameters()
        {
            return PartialView(AppPagesLinks.Admin.ApplicationParametersPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> Licensing()
        {
            return PartialView(AppPagesLinks.Admin.LicensingPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> AutoReminders()
        {
            return PartialView(AppPagesLinks.Admin.AutoRemindersPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SQLBrowser()
        {
            return PartialView(AppPagesLinks.Admin.SQLBrowserPageLink);
        }
    }
}
 