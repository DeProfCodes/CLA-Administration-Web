using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules.ContentLibrary;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
using CLA_Administration_Web.ViewModels.Modules.Rss;
using CLA_Administration_Web.ViewModels.Reports;

namespace CLA_Administration_Web.Services
{
    public class LocalDataStorage
    {
        public static class StagingData
        {
            // PST Modules
            public static List<ModulePSTDataViewModel> AllPopupData { get; set; }

            public static List<ModulePSTDataViewModel> AllTickerData { get; set; }

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            // LDS Modules

            public static List<ModuleLDSDataViewModel> AllLockedDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllScreensavers { get; set; }

            public static List<RssCategoryOverviewViewModel> AllRSSCategories { get; set; }

            public static List<RssFeedOverviewViewModel> AllRSSFeed { get; set; }


            public static PopupReports PopupReports { get; set; }

            public static PopupReportsViewModel AllPopupReports {get; set; }

            public static SurveyReports SurveyReports { get; set; }

            public static TickerReports TickerReports { get; set; }


            public static PolicyReports PolicyReports { get; set; }
        }

        public static class LiveData
        {
            public static List<ModulePSTDataViewModel> AllPopupData { get; set; }

            public static List<ModulePSTDataViewModel> AllTickerData { get; set; }

            public static List<ModulePSTDataViewModel> AllSurveysData { get; set; }

            public static List<SurveyQuestionViewModel> AllSurveyQuestions { get; set; }

            // LDS Modules

            public static List<ModuleLDSDataViewModel> AllLockedDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllDesktops { get; set; }

            public static List<ModuleLDSDataViewModel> AllScreensavers { get; set; }

            public static List<RssCategoryOverviewViewModel> AllRSSCategories { get; set; }

            public static List<RssFeedOverviewViewModel> AllRSSFeed { get; set; } 
        }

        public static List<ContentLibraryCategoryTree> AllContentLibraryCategories {get; set; }

        public static List<ContentLibraryContentModel> AllContentLibraryContents { get; set; }

        public static ReportsDataViewModel ReportsData { get; set; } = new();

        public static List<ModulePSTDataViewModel> GetLocalModulePSTAllData(ModuleNamesType moduleName)
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

        // Update PST Modules Data
        public static void UpdatePopupsData(List<ModulePSTDataViewModel> data)
        {
            StagingData.AllPopupData = data;
        }

        public static void UpdateTickersData(List<ModulePSTDataViewModel> data)
        {
            StagingData.AllTickerData = data;
        }

        public static void UpdateSurveysData(List<ModulePSTDataViewModel> data)
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

        public static void UpdateRSSCategoriesData(List<RssCategoryOverviewViewModel> data, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                StagingData.AllRSSCategories = data;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                LiveData.AllRSSCategories = data;
            }
        }

        public static void UpdateRSSFeedData(List<RssFeedOverviewViewModel> data, StagingLiveType stagingLiveType)
        {
            if (stagingLiveType == StagingLiveType.Staging)
            {
                StagingData.AllRSSFeed = data;
            }
            else if (stagingLiveType == StagingLiveType.Live)
            {
                LiveData.AllRSSFeed = data;
            }
        }

        public static void UpdateContentLibraryCategoriesData(List<ContentLibraryCategoryTree> data)
        {
            AllContentLibraryCategories = data;
        }

        public static void UpdateContentLibraryContentsData(List<ContentLibraryContentModel> data)
        {
            AllContentLibraryContents = data;
        }
    }
}
