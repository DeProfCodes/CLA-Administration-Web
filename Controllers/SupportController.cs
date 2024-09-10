using CLA_Administration_Web.Helpers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class SupportController : Controller
    {
        private readonly ILogger<SupportController> _logger;

        public SupportController(ILogger<SupportController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> AboutUs()
        {
            return PartialView(AppPagesLinks.Support.AboutUsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> Tutorials()
        {
            return PartialView(AppPagesLinks.Support.TutorialsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> RemoteAssistance()
        {
            return PartialView(AppPagesLinks.Support.RemoteAssistancePageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ContactUs()
        {
            return PartialView(AppPagesLinks.Support.ContactUsPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> FAQ()
        {
            return PartialView(AppPagesLinks.Support.FAQPageLink);
        }
    }
}
 