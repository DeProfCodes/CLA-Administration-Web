using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Layout;
using CLA_Administration_Web.ViewModels.Layouts;
using Microsoft.AspNetCore.Mvc;

namespace CLA_Administration_Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ILogger<DashboardController> _logger;

        public DashboardController(ILogger<DashboardController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> TopNavigation()
        {
            return PartialView(AppPagesLinks.Layouts.TopNavigationPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> LeftNavigation()
        {
            var leftNavViewModel = new LeftNavigationViewModel
            {
                ModulesLeftNavigation = LayoutsHelper.GetModuleNamesAndPages(),
                SettingsLeftNavigation = LayoutsHelper.GetSettingsNamesTypes(),
                ReportsLeftNavigation = LayoutsHelper.GetReportsNamesTypes(),
                SupportLeftNavigation = LayoutsHelper.GetSupportNamesTypes(),
                AccountLeftNavigation = LayoutsHelper.GetAccountNamesTypes(),
            };

            return PartialView(AppPagesLinks.Layouts.LeftNavigationPageLink, leftNavViewModel);
        }

        public IActionResult Dashboard()
        {
            return PartialView(AppPagesLinks.Dashboard.DashboardHomePageLink);
        }

        public IActionResult Calendar()
        {
            return PartialView(AppPagesLinks.Dashboard.DashboardCalendarPageLink);
        }
    }
}
 