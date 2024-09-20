using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PSTR;

namespace CLA_Administration_Web.Services
{
    public class LocalDataStorage
    {
        // PSTR Modules
        public static class StagingData
        {
            public static List<ModulePSTRDataViewModel> AllPopupData { get; set; }

            public static List<ModulePSTRDataViewModel> AllTickerData { get; set; }

            public static List<ModulePSTRDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            // LDS Modules

            public static List<ModuleLDSDataViewModel> AllLockedDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllScreensavers { get; set; }
        }

        public static class LiveData
        {
            public static List<ModulePSTRDataViewModel> AllPopupData { get; set; }

            public static List<ModulePSTRDataViewModel> AllTickerData { get; set; }

            public static List<ModulePSTRDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            // LDS Modules

            public static List<ModuleLDSDataViewModel> AllLockedDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllScreensavers { get; set; }
        }

        public static List<ModulePSTRDataViewModel> GetLocalModulePSTRAllData(ModuleNamesType moduleName)
        {
            switch (moduleName)
            {
                case ModuleNamesType.Popup: return StagingData.AllPopupData;
                case ModuleNamesType.Ticker: return StagingData.AllTickerData;
                case ModuleNamesType.Survey: return StagingData.AllSurveysData;
                default: return new();
            }
        }

        public static List<ModuleLDSDataViewModel> GetLocalModuleLDSAllData(ModuleNamesType moduleName, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                switch (moduleName)
                {
                    case ModuleNamesType.LockedDesktop: return StagingData.AllLockedDesktops;
                    case ModuleNamesType.Desktop: return StagingData.AllDesktops;
                    case ModuleNamesType.Screensaver: return StagingData.AllScreensavers;
                    default: return new();
                }
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                switch (moduleName)
                {
                    case ModuleNamesType.LockedDesktop: return LiveData.AllLockedDesktops;
                    case ModuleNamesType.Desktop: return LiveData.AllDesktops;
                    case ModuleNamesType.Screensaver: return LiveData.AllScreensavers;
                    default: return new();
                }
            }
            return new();
        }

        // Update PSTR Modules Data
        public static void UpdatePopupsData(List<ModulePSTRDataViewModel> data)
        {
            StagingData.AllPopupData = data;
        }

        public static void UpdateTickersData(List<ModulePSTRDataViewModel> data)
        {
            StagingData.AllTickerData = data;
        }

        public static void UpdateSurveysData(List<ModulePSTRDataViewModel> data)
        {
            StagingData.AllSurveysData = data;
        }

        public static void UpdateSurveysQuestions(List<SurveyQuestionViewModel> data)
        {
            StagingData.AllSurveyQuestions = data;
        }

        // Update LDS Modules Data
        public static void UpdateLockedDesktopsData(List<ModuleLDSDataViewModel> data, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                StagingData.AllLockedDesktops = data;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                LiveData.AllLockedDesktops = data;
            }
        }

        public static void UpdateDesktopsData(List<ModuleLDSDataViewModel> data, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                StagingData.AllDesktops = data;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                LiveData.AllDesktops = data;
            }
        }

        public static void UpdateScreensaversData(List<ModuleLDSDataViewModel> data, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                StagingData.AllScreensavers = data;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                LiveData.AllScreensavers = data;
            }
        }
    }
}
