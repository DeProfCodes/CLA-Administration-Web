using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Models;
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

        #region LAYOUTS

        [HttpGet]
        public async Task<IActionResult> TopNavigation()
        {
            return PartialView(DashboardLinkPages.Layouts.TopNavigationPageLink);
        }

        [HttpGet]
        public async Task<IActionResult> LeftNavigation()
        {
            return PartialView(DashboardLinkPages.Layouts.LeftNavigationPageLink);
        }

        #endregion

        public IActionResult Dashboard()
        {
            return PartialView(DashboardLinkPages.DashboardPageLink);
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
 