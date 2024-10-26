using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.Services.API;
using CLA_Administration_Web.ViewModels.API.Reports;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Services.Reporting
{
    public class ReportingService : BaseService, IReportingService
    {
        public string apiControllerName { get; set; }

        public ReportingService(IApiService webApi) : base(webApi)
        {
            apiControllerName = "Reporting";
        }

        #region PST Modules

        #region Modules 

        public async Task<string> GetModuleListForReporting(ReportsNamesType reportNameType, string effectiveFrom, string effectiveTo, int isAutomated = 0, bool connectToLive = false)
        {
            var endpoint = $"{apiControllerName}/GetModulesListForReporting?moduleName={reportNameType.GetDisplayName().ToLower()}&" +
                           $"effectiveFrom={effectiveFrom}&effectiveTo={effectiveTo}&isAutomated={isAutomated}&connectToLive={connectToLive}";

            var apiResponse = await _webApi.HttpGetAsync(endpoint);

            return apiResponse;
        }

        public async Task<string> GetModuleSummaryReport(ModuleSummaryParamsViewModel moduleParams, ReportsNamesType reportNameType, string reportType)
        {
            try
            {
                var endpoint = $"{apiControllerName}/GetModuleSummaryReport?moduleName={reportNameType.GetDisplayName().ToLower()}&report={reportType}" +
                               $"&moduleId={moduleParams.ModuleId}&useMachineId={moduleParams.UseMachineId}&showComplete={moduleParams.ShowComplete}" +
                               $"&showOutstanding={moduleParams.ShowOutstanding}&showActive={moduleParams.ShowActive}&environment={moduleParams.Environment}" +
                               $"&active={moduleParams.Active}&dormant={moduleParams.Dormant}&inactive={moduleParams.InActive}&connectToLive={moduleParams.ConnectToLive}";

                var apiResponse = await _webApi.HttpGetAsync(endpoint);

                return apiResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Tickers

        public async Task<List<ModulePSTDataViewModel>> GetAllTickersData()
        {
            return ModulesMockData.StagingData.AllTickersData;
        }

        public async Task<ModulePSTDataViewModel> GetTickerById(int tickerId, StagingLiveType stagingLive)
        {

            ModulePSTDataViewModel tickerData = null;

            if (stagingLive == StagingLiveType.Staging)
            {
                tickerData = ModulesMockData.StagingData.AllTickersData.FirstOrDefault(x => x.Id == tickerId);
            }
            else if (stagingLive == StagingLiveType.Live)
            {
                tickerData = ModulesMockData.LiveData.AllTickersData.FirstOrDefault(x => x.Id == tickerId);
            }
            return tickerData;
        }

        #endregion

        #region Surveys

        public async Task<List<ModulePSTDataViewModel>> GetAllSurveysData()
        {
            return ModulesMockData.StagingData.AllSurveysData;
        }

        public async Task<ModulePSTDataViewModel> GetSurveyById(int surveyId, StagingLiveType stagingLiveType)
        {
            ModulePSTDataViewModel surveyData = null;
            if (stagingLiveType == StagingLiveType.Staging)
            {
                surveyData = LocalDataStorage.StagingData.AllSurveysData.FirstOrDefault(s => s.Id == surveyId);
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                surveyData = LocalDataStorage.LiveData.AllSurveysData.FirstOrDefault(s => s.Id == surveyId);
            }
            return surveyData;
        }

        public async Task<List<SurveyQuestionViewModel>> GetAllSurveysQuestions()
        {
            return ModulesMockData.StagingData.AllSurveyQuestions;
        }

        public async Task<List<SurveyQuestionViewModel>> GetSurveyAllQuestions(int surveyId)
        {
            var surveyQuestions = ModulesMockData.StagingData.AllSurveyQuestions.Where(x => x.SurveyId == surveyId).ToList();

            return surveyQuestions;
        }

        
        #endregion

        #endregion

        #region RSS

        public async Task<List<RssCategoryOverviewViewModel>> GetAllRssCategories(StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                return ModulesMockData.StagingData.AllRSSCategories;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                return ModulesMockData.LiveData.AllRSSCategories;
            }
            return null;
        }

        public async Task<List<RssFeedOverviewViewModel>> GetAllRssFeeds(StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                return ModulesMockData.StagingData.AllRSSFeed;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                return ModulesMockData.LiveData.AllRSSFeed;
            }
            return null;
        }

        #endregion

        #region Content Library

        public async Task<List<ContentLibraryCategoryModel>> GetAllContentLibraryCategories()
        {
            return null;// ModulesMockData.AllContentLibraryCategories;
        }

        public async Task<List<ContentLibraryContentModel>> GetAllContentLibraryContents()
        {
            return ModulesMockData.AllContentLibraryContents;
        }

        #endregion

        #region LDS Modules

        #region Screensavers

        public async Task<List<ModuleLDSDataViewModel>> GetAllScreensaversData(StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                return ModulesMockData.StagingData.AllScreensaversData;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                return ModulesMockData.LiveData.AllScreensaversData;
            }
            return null;
        }

        #endregion

        #region LockedDesktops

        public async Task<List<ModuleLDSDataViewModel>> GetAllLockedDesktopsData(StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                return ModulesMockData.StagingData.AllLockedDesktopsData;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                return ModulesMockData.LiveData.AllLockedDesktopsData;
            }
            return null;
        }

        #endregion

        #region Desktops

        public async Task<List<ModuleLDSDataViewModel>> GetAllDesktopsData(StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                return ModulesMockData.StagingData.AllDesktopsData;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                return ModulesMockData.LiveData.AllDesktopsData;
            }
            return null;
        }

        #endregion

        #endregion
    }
}
