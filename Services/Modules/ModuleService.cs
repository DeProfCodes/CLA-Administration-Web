using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PSTR;

namespace CLA_Administration_Web.Services.Modules
{
    public class ModuleService : IModuleService
    {
        public ModuleService()
        {
         
        }

        #region PSTR Modules

        #region Popups 

        public async Task<List<ModulePSTRDataViewModel>> GetAllPopupsData()
        {
            return ModulesMockData.StagingData.AllPopupsData;    
        }

        #endregion

        #region Tickers

        public async Task<List<ModulePSTRDataViewModel>> GetAllTickersData()
        {
            return ModulesMockData.StagingData.AllTickersData;
        }

        #endregion

        #region Surveys
        
        public async Task<List<ModulePSTRDataViewModel>> GetAllSurveysData()
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

        #region LockedDesktops

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
