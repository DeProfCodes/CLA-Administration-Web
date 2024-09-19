using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
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

        public async Task<IActionResult> ModulesOverviewFilter(ModuleNamesType moduleNameType, string status, string userType, string startDate, string endDate)
        {
            var dataSource = LocalDataStorage.GetLocalModuleAllData(moduleNameType);

            var moduleFilterDataVm = new ModuleFilterOverviewModel
            {
                ModuleName = moduleNameType,
                ModuleDetailsPage = ModulesHelper.GetModuleDetailsPage(moduleNameType),
                FilterTitle = ModulesHelper.GetModuleOverviewTitleText(moduleNameType, status, userType, startDate, endDate),
                ModulesData = ModulesHelper.FilterModulesData(dataSource, status, userType, startDate, endDate)
            };

            return PartialView(AppPagesLinks.Modules.ModulesFilterOverviewPageLink, moduleFilterDataVm);
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

        public async Task<IActionResult> PopupDetails(int popupId)
        {
            var popupDetails = LocalDataStorage.AllPopupData.Where(x => x.Id == popupId).FirstOrDefault();  

            return PartialView(AppPagesLinks.Modules.PopupDetailsPageLink, popupDetails);
        }

        public IActionResult AddNewPopup()
        {
            return PartialView(AppPagesLinks.Modules.PopupAddNewPageLink);
        }

        #endregion

        #region Survey

        public async Task<IActionResult> SurveyOverview()
        {
            var surveyDataViewModel = await _moduleService.GetAllTickersData();

            surveyDataViewModel.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            LocalDataStorage.UpdateSurveysData(surveyDataViewModel);

            return PartialView(AppPagesLinks.Modules.SurveyOverviewPageLink);
        }

        public async Task<IActionResult> SurveyDetails(int surveyId)
        {
            var surveyDetails = LocalDataStorage.AllSurveysData.Where(x => x.Id == surveyId).FirstOrDefault();

            return PartialView(AppPagesLinks.Modules.SurveyDetailsPageLink, surveyDetails);
        }

        public IActionResult AddNewSurvey()
        {
            return PartialView(AppPagesLinks.Modules.SurveyAddNewPageLink);
        }

        #endregion

        #region Ticker
        public async Task<IActionResult> TickerOverview()
        {
            var tickerDataViewModel = await _moduleService.GetAllTickersData();

            tickerDataViewModel.ForEach(t =>
            {
                t.Status = ModulesHelper.GetModuleStatus(t.EffectiveFrom, t.EffectiveTo);
                t.EffectiveFromDate = TypesParserHelper.ParseDate(t.EffectiveFrom);
                t.EffectiveToDate = TypesParserHelper.ParseDate(t.EffectiveTo);
            });

            LocalDataStorage.UpdateTickersData(tickerDataViewModel);

            return PartialView(AppPagesLinks.Modules.TickerOverviewPageLink, tickerDataViewModel);
        }

        public async Task<IActionResult> TickerDetails(int tickerId)
        {
            var tickerDetails = LocalDataStorage.AllTickerData.Where(x => x.Id == tickerId).FirstOrDefault();

            return PartialView(AppPagesLinks.Modules.TickerDetailsPageLink, tickerDetails);
        }
        
        public IActionResult AddNewTicker()
        {
            return PartialView(AppPagesLinks.Modules.TickerAddNewPageLink);
        }

        #endregion

        public IActionResult RSSOverview()
        {
            return PartialView(AppPagesLinks.Modules.RSSOverviewPageLink);
        }

        public IActionResult RSSAddNew()
        {
            return PartialView(AppPagesLinks.Modules.RSSAddNewPageLink);
        }
    }
}
 