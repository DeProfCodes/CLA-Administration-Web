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
            return PartialView(AppPagesLinks.Modules.ContentLibraryCategoriesPageLink);
        }

        public IActionResult ContentLibraryContent()
        {
            return PartialView(AppPagesLinks.Modules.ContentLibraryContentsPageLink);
        }

        public IActionResult DesktopOverview()
        {
            return PartialView(AppPagesLinks.Modules.DesktopOverviewPageLink);
        }

        public IActionResult DesktopAddNew()
        {
            return PartialView(AppPagesLinks.Modules.DesktopAddNewPageLink);
        }

        public IActionResult LockedDesktopOverview()
        {
            return PartialView(AppPagesLinks.Modules.LockedDesktopOverviewPageLink);
        }

        public IActionResult LockedDesktopAddNew()
        {
            return PartialView(AppPagesLinks.Modules.LockedDesktopAddNewPageLink);
        }

        public IActionResult ScreensaverOverview()
        {
            return PartialView(AppPagesLinks.Modules.ScreensaverOverviewPageLink);
        }

        public IActionResult ScreensaverAddNew()
        {
            return PartialView(AppPagesLinks.Modules.ScreensaverAddNewPageLink);
        }

        public IActionResult PopupOverview()
        {
            return PartialView(AppPagesLinks.Modules.PopupOverviewPageLink);
        }

        public IActionResult PopupAddNew()
        {
            return PartialView(AppPagesLinks.Modules.PopupAddNewPageLink);
        }

        public IActionResult SurveyOverview()
        {
            return PartialView(AppPagesLinks.Modules.SurveyOverviewPageLink);
        }

        public IActionResult SurveyAddNew()
        {
            return PartialView(AppPagesLinks.Modules.SurveyAddNewPageLink);
        }

        public IActionResult TickerOverview()
        {
            return PartialView(AppPagesLinks.Modules.TickerOverviewPageLink);
        }

        public IActionResult TickerAddNew()
        {
            return PartialView(AppPagesLinks.Modules.TickerAddNewPageLink);
        }
    }
}
 