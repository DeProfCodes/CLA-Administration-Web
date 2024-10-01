using CLA_Administration_Web.Helpers.Constants;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Helpers.Modules;
using CLA_Administration_Web.Helpers.Shared;
using CLA_Administration_Web.Models;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.Services.Modules;
using CLA_Administration_Web.ViewModels.Modules;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.GanttChart;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLACommonFunctionsLibrary_NET.Helpers;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;
using CLACommonFunctionsLibrary_NET.Helpers.Logs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CLA_Administration_Web.Controllers
{
    public class ModulesController : Controller
    {
        private readonly IModuleService _moduleService;

        private readonly ILogger<ModulesController> _logger;

        public readonly EventLoggerHelper eventLogger;

        public ModulesController(IModuleService moduleService, ILogger<ModulesController> logger)
        {
            _moduleService = moduleService;
            _logger = logger;

            eventLogger = new EventLoggerHelper("CLA Web Admin Tool");
        }

        #region All

        public IActionResult AllModules()
        {
            return PartialView(AppPagesLinks.Modules.AllModulesPageLink);
        }

        #endregion

        #region Modules PST: Popups, Surveys, Tickers

        public async Task<IActionResult> ModulePSTTableOverview(ModuleNamesType moduleNameType, string status, string userType, string startDate, string endDate)
        {
            var dataSource = LocalDataStorage.GetLocalModulePSTAllData(moduleNameType);

            var moduleFilterDataVm = new ModulePSTFilterOverviewModel
            {
                ModuleName = moduleNameType,
                ModuleDetailsPage = ModulesHelper.GetModuleDetailsPage(moduleNameType),
                FilterTitle = ModulesHelper.GetModuleOverviewTitleText(moduleNameType, status, StagingLiveType.Staging, userType, startDate, endDate),
                ModulesData = ModulesHelper.FilterModulesPSTData(dataSource, status, userType, startDate, endDate)
            };

            return PartialView(AppPagesLinks.Modules.ModulePSTTableOverviewPageLink, moduleFilterDataVm);
        }

        #endregion

        #region Modules LDS: Lockscreen, Desktops, Screensavers

        public async Task<IActionResult> ModuleLDSTableOverview(ModuleNamesType moduleNameType, string status, StagingLiveType stagingLive, string startDate, string endDate)
        {
            var moduleFilterDataVm = ModulesHelper.GetModuleLDSFilterOverview(moduleNameType, stagingLive, status, startDate, endDate);

            return PartialView(AppPagesLinks.Modules.ModuleLDSTableOverviewPageLink, moduleFilterDataVm);
        }

        public async Task<IActionResult> ModuleLDSCalendarOverview(ModuleNamesType moduleNameType, string status, StagingLiveType stagingLive, string startDate, string endDate)
        {
            var moduleFilterDataVm = ModulesHelper.GetModuleLDSFilterOverview(moduleNameType, stagingLive, status, startDate, endDate);

            return PartialView(AppPagesLinks.Modules.ModuleLDSCalendarOverviewPageLink, moduleFilterDataVm);
        }

        public async Task<IActionResult> ModuleLDSGanttOverview(ModuleNamesType moduleNameType, string status, StagingLiveType stagingLive, string startDate, string endDate)
        {
            var moduleFilterDataVm = ModulesHelper.GetModuleLDSFilterOverview(moduleNameType, stagingLive, status, startDate, endDate);

            var data = LocalDataStorage.GetLocalModuleLDSAllData(moduleNameType, stagingLive);

            var filteredData = ModulesHelper.FilterModulesLDSData(data, status, startDate, endDate);

            var ganttData = ModulesHelper.GetGanttChartData(filteredData);

            var ganttChartVM = new GanttChartDataViewModel
            {
                ModuleName = moduleNameType,
                FilterTitle = ModulesHelper.GetModuleOverviewTitleText(moduleNameType, status, stagingLive, "All", startDate, endDate),
                GanttData = ganttData,
                GanttChartHeight = ModulesHelper.GetGanttChartHeight(ganttData.Count),
                GanttChartToolTip = ModulesHelper.GetGanttToolTipDetailsLDS(filteredData)
            };

            return PartialView(AppPagesLinks.Modules.ModuleLDSGanttOverviewPageLink, ganttChartVM);
        }

        #endregion


        public IActionResult ContentLibraryCategories()
        {
            var data = new ContentLibraryCategoryViewModel();

            try
            {
                data.CategoriesTrees = ModulesMockData.GenerateDummyDataContentLibraryCategories();
            }
            catch(Exception ex)
            {
                eventLogger.WriteToEventLog($"Failed to read, details ContentLibraryCategories \n Error: {ex.Message}\n Stacktrace: {ex.StackTrace}\n Full Exception Details: {ex}");
                _logger.LogError($"Settings file was not read properly, details: {ex.Message}", ex);
            }
            return PartialView(AppPagesLinks.Modules.ContentLibraryCategoriesPageLink, data);
        }

        public IActionResult ContentLibraryCategoryDetails(int categoryId)
        {
            var data = ModulesMockData.AllContentLibraryCategories.FirstOrDefault();
            data.CategoryId = categoryId;

            return PartialView(AppPagesLinks.Modules.ContentLibraryCategoryDetailsPageLink, data);
        }

        public async Task<IActionResult> ContentLibraryContent(int categoryId)
        {
            var contents = await _moduleService.GetAllContentLibraryContents();

            contents.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            var contentsViewModel = new ContentLibraryContentsViewModel
            {
                CategoryId = categoryId,
                ContentLibraryContents = contents
            };

            LocalDataStorage.UpdateContentLibraryContentsData(contents);

            return PartialView(AppPagesLinks.Modules.ContentLibraryContentsPageLink, contentsViewModel);
        }

        public async Task<IActionResult> ContentLibraryContentDetails(int contentId)
        {
            var contentInfo = ModulesMockData.AllContentLibraryContents.FirstOrDefault(x => x.ContentId == contentId);
            
            contentInfo.TargetedModulesFullName = ModulesHelper.ConvertTargetedModulesToFullNames(contentInfo.TargetedModules);

            return PartialView(AppPagesLinks.Modules.ContentLibraryContentDetailsPageLink, contentInfo);
        }

        public async Task<IActionResult> DesktopOverview()
        {
            var desktopStaging = await _moduleService.GetAllDesktopsData(StagingLiveType.Staging);
            var desktopLive = await _moduleService.GetAllDesktopsData(StagingLiveType.Live);

            desktopStaging.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });
            desktopLive.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            LocalDataStorage.UpdateDesktopsData(desktopStaging, StagingLiveType.Staging);
            LocalDataStorage.UpdateDesktopsData(desktopLive, StagingLiveType.Live);

            return PartialView(AppPagesLinks.Modules.DesktopOverviewPageLink);
        }

        public async Task<IActionResult> DesktopDetails(int desktopId)
        {
            var desktopVm = LocalDataStorage.StagingData.AllDesktops.FirstOrDefault(x => x.Id == desktopId);

            return PartialView(AppPagesLinks.Modules.DesktopDetailsPageLink, desktopVm);
        }

        public IActionResult DesktopAddNew()
        {
            return PartialView(AppPagesLinks.Modules.DesktopAddNewPageLink);
        }

        #region LockedDesktop
        public async Task<IActionResult> LockedDesktopOverview()
        {
            var lockedDesktopStaging = await _moduleService.GetAllLockedDesktopsData(StagingLiveType.Staging);
            var lockedDesktopLive = await _moduleService.GetAllLockedDesktopsData(StagingLiveType.Live);

            lockedDesktopStaging.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });
            lockedDesktopLive.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            LocalDataStorage.UpdateLockedDesktopsData(lockedDesktopStaging, StagingLiveType.Staging);
            LocalDataStorage.UpdateLockedDesktopsData(lockedDesktopLive, StagingLiveType.Live);

            return PartialView(AppPagesLinks.Modules.LockedDesktopOverviewPageLink);
        }

        public async Task<IActionResult> LockedDesktopDetails(int lockedDesktopId)
        {
            var lockeddesktopVm = LocalDataStorage.StagingData.AllLockedDesktops.FirstOrDefault(x => x.Id == lockedDesktopId);

            return PartialView(AppPagesLinks.Modules.LockedDesktopDetailsPageLink, lockeddesktopVm);
        }

        public IActionResult LockedDesktopAddNew()
        {
            return PartialView(AppPagesLinks.Modules.LockedDesktopAddNewPageLink);
        }

        #endregion

        #region Screensaver
        public async Task<IActionResult> ScreensaverOverview()
        {
            var screensaversStaging = await _moduleService.GetAllScreensaversData(StagingLiveType.Staging);
            var screensaversLive = await _moduleService.GetAllScreensaversData(StagingLiveType.Live);
            
            screensaversStaging.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });
            screensaversLive.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            LocalDataStorage.UpdateScreensaversData(screensaversStaging, StagingLiveType.Staging);
            LocalDataStorage.UpdateScreensaversData(screensaversLive, StagingLiveType.Live);

            return PartialView(AppPagesLinks.Modules.ScreensaverOverviewPageLink);
        }

        public async Task<IActionResult> ScreensaverDetails(int screensaverId)
        {
            var screensaverVm = LocalDataStorage.StagingData.AllScreensavers.FirstOrDefault(x => x.Id == screensaverId);

            return PartialView(AppPagesLinks.Modules.ScreensaverDetailsPageLink, screensaverVm);
        }

        public IActionResult ScreensaverAddNew()
        {
            return PartialView(AppPagesLinks.Modules.ScreensaverAddNewPageLink);
        }

        #endregion

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
            var popupDetails = LocalDataStorage.StagingData.AllPopupData.Where(x => x.Id == popupId).FirstOrDefault();  

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
            var allSurveyQuestions = await _moduleService.GetAllSurveysQuestions();

            surveyDataViewModel.ForEach(s =>
            {
                s.Status = ModulesHelper.GetModuleStatus(s.EffectiveFrom, s.EffectiveTo);
                s.EffectiveFromDate = TypesParserHelper.ParseDate(s.EffectiveFrom);
                s.EffectiveToDate = TypesParserHelper.ParseDate(s.EffectiveTo);
            });

            LocalDataStorage.UpdateSurveysData(surveyDataViewModel);
            LocalDataStorage.UpdateSurveysQuestions(allSurveyQuestions);

            return PartialView(AppPagesLinks.Modules.SurveyOverviewPageLink);
        }

        public async Task<IActionResult> SurveyDetails(int surveyId)
        {
            var surveyDetails = LocalDataStorage.StagingData.AllSurveysData.Where(x => x.Id == surveyId).FirstOrDefault();

            return PartialView(AppPagesLinks.Modules.SurveyDetailsPageLink, surveyDetails);
        }

        public IActionResult SurveyQuestionsOverview(int surveyId)
        {
            var surveyQuestionsOverviewVM = new SurveyQuestionsOverviewViewModel
            {
                SurveyId = surveyId,
                SurveyQuestions = LocalDataStorage.StagingData.AllSurveyQuestions.Where(x => x.SurveyId == surveyId).ToList(),
            };
            return PartialView(AppPagesLinks.Modules.SurveyQuestionsOverviewPageLink, surveyQuestionsOverviewVM);
        }

        public IActionResult SurveyQuestionDetails(int surveyId, int questionId)
        {
            var surveyQuestionInfo = LocalDataStorage.StagingData.AllSurveyQuestions.FirstOrDefault(x => x.SurveyId == surveyId && x.QuestionId == questionId);

            return PartialView(AppPagesLinks.Modules.SurveyQuestionDetailsPageLink, surveyQuestionInfo);
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
            var tickerDetails = LocalDataStorage.StagingData.AllTickerData.Where(x => x.Id == tickerId).FirstOrDefault();

            return PartialView(AppPagesLinks.Modules.TickerDetailsPageLink, tickerDetails);
        }
        
        public IActionResult AddNewTicker()
        {
            return PartialView(AppPagesLinks.Modules.TickerAddNewPageLink);
        }

        #endregion

        #region RSS
        public async Task<IActionResult> RssCategoryOverview()
        {
            var rssCategories = await _moduleService.GetAllRssCategories(StagingLiveType.Staging);

            LocalDataStorage.UpdateRSSCategoriesData(rssCategories, StagingLiveType.Staging);

            return PartialView(AppPagesLinks.Modules.RssCategoryOverviewPageLink, rssCategories);
        }

        public async Task<IActionResult> RssCategoryDetails(int rssCategoryId)
        {
            var rssCategoryInfo = LocalDataStorage.StagingData.AllRSSCategories.FirstOrDefault(x => x.CategoryId == rssCategoryId);

            return PartialView(AppPagesLinks.Modules.RssCategoryDetailsPageLink, rssCategoryInfo);
        }

        public async Task<IActionResult> RssFeedOverview(int rssCategoryId)
        {
            var rssFeedsData = await _moduleService.GetAllRssFeeds(StagingLiveType.Staging);

            LocalDataStorage.UpdateRSSFeedData(rssFeedsData, StagingLiveType.Staging);

            rssFeedsData = rssFeedsData.Where(x => x.CategoryId == rssCategoryId).ToList();

            return PartialView(AppPagesLinks.Modules.RssFeedOverviewPageLink, rssFeedsData);
        }

        public async Task<IActionResult> RssFeedDetails(int rssCategoryId, int rssFeedId)
        {
            var rssCategoryInfo = LocalDataStorage.StagingData.AllRSSFeed.FirstOrDefault(x => x.CategoryId == rssCategoryId && x.FeedId == rssFeedId);

            return PartialView(AppPagesLinks.Modules.RssFeedDetailsPageLink, rssCategoryInfo);
        }

        public IActionResult RSSAddNew()
        {
            return PartialView(AppPagesLinks.Modules.RSSAddNewPageLink);
        }

        #endregion

        #region Module Additional Components

        public async Task<IActionResult> ModuleContentPreviewer(ModuleContentType contentPreviewType)
        {
            var page = "";

            if (contentPreviewType == ModuleContentType.Image)
                page = AppPagesLinks.Modules.ModuleImagePreviewerPageLink;

            if (contentPreviewType == ModuleContentType.Audio)
                page = AppPagesLinks.Modules.ModuleAudioPreviewerPageLink;


            if (contentPreviewType == ModuleContentType.Video)
                page = AppPagesLinks.Modules.ModuleVideoPreviewerPageLink;

            if (contentPreviewType == ModuleContentType.Document)
                page = AppPagesLinks.Modules.ModuleDocumentPreviewerPageLink;

            return PartialView(page);
        }

        #endregion
    }
}
 