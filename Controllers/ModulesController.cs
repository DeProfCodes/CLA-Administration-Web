using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Modules;
using CLA_Administration_Web.Models;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.Services.Modules;
using CLA_Administration_Web.ViewModels.Modules;
using CLACommonFunctionsLibrary_NET.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CLA_Administration_Web.Controllers
{
    public class ModulesController : Controller
    {
        private readonly IModuleService _moduleService;

        private readonly ILogger<ModulesController> _logger;

        public ModulesController(IModuleService moduleService, ILogger<ModulesController> logger)
        {
            _moduleService = moduleService;
            _logger = logger;
        }

        public IActionResult AllModules()
        {
            return PartialView(AppPagesLinks.Modules.AllModulesPageLink);
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

        #region Popup
        
        public async Task<IActionResult> PopupOverview()
        {
            var popupDataViewModel = await _moduleService.GetAllPopupsData();

            popupDataViewModel.ForEach(p => 
            {
                p.Status = ModulesHelper.GetModuleStatus(p.EffectiveFrom, p.EffectiveTo); 
                p.EffectiveFromDate = TypesParserHelper.ParseDate(p.EffectiveFrom);
                p.EffectiveToDate = TypesParserHelper.ParseDate(p.EffectiveTo);
            });

            LocalDataStorage.UpdatePopupsData(popupDataViewModel);

            return PartialView(AppPagesLinks.Modules.PopupOverviewPageLink, popupDataViewModel);
        }

        public async Task<IActionResult> _FilterPopupsOverview(string status, string userType, string startDate, string endDate)
        {
            Thread.Sleep(2000);
            var popupFilterDataVm = new PopupFilterOverviewModel
            {
                FilterTitle = ModulesHelper.GetPopupOverviewText(status, userType, startDate, endDate),
                PopupsData = ModulesHelper.FilterPopupsData(LocalDataStorage.AllPopupData, status, userType, startDate, endDate)
            };
            return PartialView(AppPagesLinks.Modules.PopupsFilterOverviewPageLink, popupFilterDataVm);
        }

        public IActionResult AddNewPopup()
        {
            return PartialView(AppPagesLinks.Modules.PopupAddNewPageLink);
        }

        #endregion

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
 