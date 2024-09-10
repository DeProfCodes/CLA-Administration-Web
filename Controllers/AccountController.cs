using CLA_Administration_Web.Helpers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AccountOverview()
        {
            return PartialView(AppPagesLinks.Account.AccountOverviewPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> SecuritySettings()
        {
            return PartialView(AppPagesLinks.Account.SecuritySettingsPageLink);
        }
    }
}
 