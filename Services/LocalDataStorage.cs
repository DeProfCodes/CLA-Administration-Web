using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Services
{
    public class LocalDataStorage
    {
        public static List<PopupViewModel> AllPopupData { get; set; }

        public static void UpdatePopupsData(List<PopupViewModel> data)
        {
            AllPopupData = data;
        }
    }
}
