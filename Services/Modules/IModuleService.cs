using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.ViewModels.Modules;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PSTR;

namespace CLA_Administration_Web.Services.Modules
{
    public interface IModuleService
    {
        #region Popups
        
        public Task<List<ModulePSTRDataViewModel>> GetAllPopupsData();

        #endregion

        #region Tickers
        
        public Task<List<ModulePSTRDataViewModel>> GetAllTickersData();


        #endregion

        #region Survey
        
        public Task<List<ModulePSTRDataViewModel>> GetAllSurveysData();

        public Task<List<SurveyQuestionViewModel>> GetAllSurveysQuestions();

        public Task<List<SurveyQuestionViewModel>> GetSurveyAllQuestions(int surveyId);

        #endregion

        #region RSS

        public Task<List<RssCategoryOverviewViewModel>> GetAllRssCategories(StagingLiveType stagingLiveType);

        public Task<List<RssFeedOverviewViewModel>> GetAllRssFeeds(StagingLiveType stagingLiveType);

        #endregion 


        public Task<List<ModuleLDSDataViewModel>> GetAllScreensaversData(StagingLiveType stagingLiveType);

        public Task<List<ModuleLDSDataViewModel>> GetAllLockedDesktopsData(StagingLiveType stagingLiveType);

        public Task<List<ModuleLDSDataViewModel>> GetAllDesktopsData(StagingLiveType stagingLiveType);
    }
}
