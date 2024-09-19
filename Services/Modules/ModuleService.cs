using CLA_Administration_Web.Helpers.MockData;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Services.Modules
{
    public class ModuleService : IModuleService
    {
        public ModuleService()
        {
         
        }

        #region Popups 
        
        public async Task<List<ModuleDataViewModel>> GetAllPopupsData()
        {
            return ModulesMockData.AllPopupsData;    
        }

        public async Task<List<ModuleDataViewModel>> GetAllTickersData()
        {
            return ModulesMockData.AllTickersData;
        }

        public async Task<List<ModuleDataViewModel>> GetAllSurveysData()
        {
            return ModulesMockData.AllSurveysData;
        }

        #endregion
    }
}
