using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Services.Modules
{
    public interface IModuleService
    {
        #region Popups
        
        public Task<List<ModuleDataViewModel>> GetAllPopupsData();

        public Task<List<ModuleDataViewModel>> GetAllTickersData();

        public Task<List<ModuleDataViewModel>> GetAllSurveysData();

        #endregion
    }
}
