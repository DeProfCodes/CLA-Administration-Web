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
        
        public async Task<List<PopupViewModule>> GetAllPopupsData()
        {
            return ModulesMockData.AllPopupsData;    
        }

        #endregion
    }
}
