using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Services.Modules
{
    public interface IModuleService
    {
        #region Popups
        
        public Task<List<PopupViewModel>> GetAllPopupsData();
        
        #endregion
    }
}
