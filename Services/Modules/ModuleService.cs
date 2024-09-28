using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;

namespace CLA_Administration_Web.Services.Modules
{
    public class ModuleService : IModuleService
    {
        public ModuleService()
        {

        }

        #region PST Modules

        #region Popups 

        public async Task<List<ModulePSTDataViewModel>> GetAllPopupsData()
        {
            return ModulesMockData.StagingData.AllPopupsData;
        }

        #endregion

        #region Tickers

        public async Task<List<ModulePSTDataViewModel>> GetAllTickersData()
        {
            return ModulesMockData.StagingData.AllTickersData;
        }

        #endregion

        #region Surveys

        public async Task<List<ModulePSTDataViewModel>> GetAllSurveysData()
        {
            return ModulesMockData.StagingData.AllSurveysData;
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
            return ModulesMockData.AllContentLibraryCategories;
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
