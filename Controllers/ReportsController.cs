using CLA_Administration_Web.Helpers.Constants;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ILogger<ReportsController> _logger;

        public ReportsController(ILogger<ReportsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> SurveyReport()
        {
            return PartialView(AppPagesLinks.Reports.SurveyPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> PopupReport()
        {
            return PartialView(AppPagesLinks.Reports.PopupPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TickerReport()
        {
            return PartialView(AppPagesLinks.Reports.TickerPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> PolicyReport()
        {
            return PartialView(AppPagesLinks.Reports.PolicyPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveUsersReport()
        {
            return PartialView(AppPagesLinks.Reports.ActiveUsersPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> ActiveMachinesReport()
        {
            return PartialView(AppPagesLinks.Reports.ActiveMachinesPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> CampaignDispatchReport()
        {
            return PartialView(AppPagesLinks.Reports.CampaignDispatchPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> TroubleshootReport()
        {
            return PartialView(AppPagesLinks.Reports.TroubleshootPageLink);
        }
    }
}
 