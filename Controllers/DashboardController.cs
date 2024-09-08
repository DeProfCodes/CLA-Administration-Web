using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Layout;
using CLA_Administration_Web.Models;
using CLA_Administration_Web.ViewModels.Layouts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
                ModuleNamesPages = LayoutsHelper.GetModuleNamesAndPages(),
                SettingsNamesType = LayoutsHelper.GetSettingsNamesTypes(),
            };

            return PartialView(AppPagesLinks.Layouts.LeftNavigationPageLink, leftNavViewModel);
        }

        public IActionResult Dashboard()
        {
            return PartialView(AppPagesLinks.DashboardHomePageLink);
        }

        public IActionResult Calendar()
        {
            return PartialView(AppPagesLinks.DashboardCalendarPageLink);
        }

        #region MODULES

        #region POPUPS

        public IActionResult Overview()
        {
            return PartialView(DashboardLinkPages.Modules.PopupPageLink);
        }

        #endregion

        #endregion

    }
}
 