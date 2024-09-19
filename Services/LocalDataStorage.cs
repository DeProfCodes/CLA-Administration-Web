using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules;

namespace CLA_Administration_Web.Services
{
    public class LocalDataStorage
    {
        public static List<ModuleDataViewModel> AllPopupData { get; set; }

        public static List<ModuleDataViewModel> AllTickerData { get; set; }

        public static List<ModuleDataViewModel> AllSurveysData { get; set; }

        public static List<ModuleDataViewModel> GetLocalModuleAllData(ModuleNamesType moduleName)
        {
            switch (moduleName)
            {
                case ModuleNamesType.Popup: return AllPopupData;
                case ModuleNamesType.Ticker: return AllTickerData;
                case ModuleNamesType.Survey: return AllSurveysData;
                default: return new();
            }
        }

        public static void UpdatePopupsData(List<ModuleDataViewModel> data)
        {
            AllPopupData = data;
        }

        public static void UpdateTickersData(List<ModuleDataViewModel> data)
        {
            AllTickerData = data;
        }

        public static void UpdateSurveysData(List<ModuleDataViewModel> data)
        {
            AllSurveysData = data;
        }
    }
}
