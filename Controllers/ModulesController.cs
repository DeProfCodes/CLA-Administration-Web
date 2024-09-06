using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLA_Administration_Web.Controllers
{
    public class ModulesController : Controller
    {
        private readonly ILogger<ModulesController> _logger;

        public ModulesController(ILogger<ModulesController> logger)
        {
            _logger = logger;
        }

        public IActionResult ContentLibraryCategories()
        {
            return PartialView(DashboardLinkPages.Modules.ContentLibraryCategoriesPageLink);
        }

        public IActionResult ContentLibraryContent()
        {
            return PartialView(DashboardLinkPages.Modules.ContentLibraryContentsPageLink);
        }

        public IActionResult DesktopOverview()
        {
            return PartialView(DashboardLinkPages.Modules.DesktopOverviewPageLink);
        }

        public IActionResult DesktopAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.DesktopAddNewPageLink);
        }

        public IActionResult LockedDesktopOverview()
        {
            return PartialView(DashboardLinkPages.Modules.LockedDesktopOverviewPageLink);
        }

        public IActionResult LockedDesktopAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.LockedDesktopAddNewPageLink);
        }

        public IActionResult ScreensaverOverview()
        {
            return PartialView(DashboardLinkPages.Modules.ScreensaverOverviewPageLink);
        }

        public IActionResult ScreensaverAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.ScreensaverAddNewPageLink);
        }

        public IActionResult PopupOverview()
        {
            return PartialView(DashboardLinkPages.Modules.PopupOverviewPageLink);
        }

        public IActionResult PopupAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.PopupAddNewPageLink);
        }

        public IActionResult SurveyOverview()
        {
            return PartialView(DashboardLinkPages.Modules.SurveyOverviewPageLink);
        }

        public IActionResult SurveyAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.SurveyAddNewPageLink);
        }

        public IActionResult TickerOverview()
        {
            return PartialView(DashboardLinkPages.Modules.TickerOverviewPageLink);
        }

        public IActionResult TickerAddNew()
        {
            return PartialView(DashboardLinkPages.Modules.TickerAddNewPageLink);
        }
    }
}
 