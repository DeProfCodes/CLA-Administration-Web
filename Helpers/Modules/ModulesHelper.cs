using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Modules;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PSTR;
using CLA_Administration_Web.ViewModels.Shared;
using CLACommonFunctionsLibrary_NET.Helpers;
using CLACommonFunctionsLibrary_NET.Helpers.Enums;

namespace CLA_Administration_Web.Helpers.Modules
{
    public class ModulesHelper
    {
        private static List<StatusViewModel> AllStatuses()
        {
            var statuses = new List<StatusViewModel>
            {
                new StatusViewModel
                {
                    StatusType = StatusType.Active,
                    CssClass = "badge bg-success"
                },
                new StatusViewModel
                {
                    StatusType = StatusType.Pending,
                    CssClass = "badge bg-warning"
                },
                new StatusViewModel
                {
                    StatusType = StatusType.Expired,
                    CssClass = "badge bg-secondary"
                }
            };
            return statuses;
        }

        public static StatusViewModel GetModuleStatus(string effectiveFrom, string effectiveTo)
        {
            var fromDate = TypesParserHelper.ParseDate(effectiveFrom);
            var toDate = TypesParserHelper.ParseDate(effectiveTo);
            var today = DateTime.Now;

            var allStatuses = AllStatuses();

            if (fromDate.Date.CompareTo(today) < 0)
            {
                if (toDate.Date.CompareTo(today) > 0)
                {
                    return allStatuses.FirstOrDefault(s => s.StatusType == StatusType.Active);
                }
                else if (toDate.Date.CompareTo(today) < 0)
                {
                    return allStatuses.FirstOrDefault(s => s.StatusType == StatusType.Expired);
                }
            }
            else if (fromDate.Date.CompareTo(today) > 0)
            {
                return allStatuses.FirstOrDefault(s => s.StatusType == StatusType.Pending);
            }
            
            return null;
        }

        public static ModulesPages GetModuleDetailsPage(ModuleNamesType moduleNameType)
        {
            switch (moduleNameType)
            {
                case ModuleNamesType.Popup: return ModulesPages.PopupDetails;
                case ModuleNamesType.Ticker: return ModulesPages.TickerDetails;
                case ModuleNamesType.Survey: return ModulesPages.SurveyDetails;
                default: return ModulesPages.None;
            }
        }

        public static List<DateTime> GetMonthsAndYears()
        {
            var result = new List<DateTime>();
            var startDate = DateTime.Now.AddMonths(-12);
            var endDate = DateTime.Now.AddMonths(6);

            while (startDate.Date.CompareTo(endDate) < 0)
            {
                result.Add(endDate);
                endDate = endDate.AddMonths(-1);
            }
            result = result.OrderByDescending(x => x).ToList(); 
            return result;
        }

        public static ModuleFilterTitle GetModuleOverviewTitleText(ModuleNamesType moduleNameType, string status, StagingLiveType stagingLive, string user, string startDate, string endDate)
        {
            var filterInfo = new ModuleFilterTitle
            {
                Status = status,
                User = user,
                StartDate = startDate,
                StagingLiveFilter = stagingLive.GetDisplayName(),
                EndDate = endDate
            };
            return filterInfo;
        }

        public static ModuleNamesType GetModuleNameTypeFromModulePage(ModulesPages modulePage)
        {
            var allModuleNameTypes = Enum.GetValues(typeof(ModuleNamesType)).Cast<ModuleNamesType>().ToList();

            return allModuleNameTypes?.FirstOrDefault(x => x.GetDisplayName() == modulePage.GetDisplayShortName()) ?? ModuleNamesType.None;
        }

        public static List<ModulePSTRDataViewModel> FilterModulesPSTRData(List<ModulePSTRDataViewModel> data, string status, string user, string startDate, string endDate)
        {
            var startDateTime = TypesParserHelper.ParseDate(startDate);
            var endDateTime = TypesParserHelper.ParseDate(endDate);
            
            status = status.ToLower();
            user = user.ToLower();

            var filteredData = data.Where(
                                           p =>  ((status != "all" && status != "") ? (p.Status.StatusType.GetDisplayName().ToLower() == status) : true) &&
                                                 (startDateTime.Date.CompareTo(p.EffectiveFromDate) <= 0 && p.EffectiveToDate.Date.CompareTo(endDateTime) <= 0) &&
                                                 (user != "all" ? (p.UserIdLastModified.ToLower() == user) : true)
                                    ).ToList();

            return filteredData;
        }

        public static List<ModuleLDSDataViewModel> FilterModulesLDSData(List<ModuleLDSDataViewModel> data, string status, string startDate, string endDate)
        {
            var startDateTime = TypesParserHelper.ParseDate(startDate);
            var endDateTime = TypesParserHelper.ParseDate(endDate);

            status = status.ToLower();
            
            var filteredData = data.Where(
                                           p => ((status != "all" && status != "") ? (p.Status.StatusType.GetDisplayName().ToLower() == status) : true) &&
                                                 startDateTime.Date.CompareTo(p.EffectiveFromDate) <= 0 && p.EffectiveToDate.Date.CompareTo(endDateTime) <= 0 
                                    ).ToList();

            return filteredData;
        }

        public static ModuleLDSFilterOverviewModel GetModuleLDSFilterOverview(ModuleNamesType moduleNameType, StagingLiveType stagingLive, string status, string startDate, string endDate)
        {
            var dataSource = LocalDataStorage.GetLocalModuleLDSAllData(moduleNameType, stagingLive);

            var moduleFilterDataVm = new ModuleLDSFilterOverviewModel
            {
                ModuleName = moduleNameType,
                ModuleDetailsPage = GetModuleDetailsPage(moduleNameType),
                FilterTitle = GetModuleOverviewTitleText(moduleNameType, status, stagingLive, "all", startDate, endDate),
                ModulesData = FilterModulesLDSData(dataSource, status, startDate, endDate)
            };

            return moduleFilterDataVm;
        }
    }
}
