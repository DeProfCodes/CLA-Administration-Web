using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Helpers.Shared;
using CLA_Administration_Web.Services;
using CLA_Administration_Web.ViewModels.Modules;
using CLA_Administration_Web.ViewModels.Modules.GanttChart;
using CLA_Administration_Web.ViewModels.Modules.LDS;
using CLA_Administration_Web.ViewModels.Modules.PST;
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

        public static List<ModulePSTDataViewModel> FilterModulesPSTData(List<ModulePSTDataViewModel> data, string status, string user, string startDate, string endDate)
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

        private static string GetGanttBarBackgroundColor(string effectiveDateFrom, string effectiveDateTo)
        {
            var startDate = TypesParserHelper.ParseDate(effectiveDateFrom);
            var endDate = TypesParserHelper.ParseDate(effectiveDateTo);

            var difference = (endDate.Date - startDate.Date).Days;

            var cssBg = "";
            
            if (difference <= 5) cssBg = "#ff3131";
            if (difference > 5 && difference <= 10) cssBg = "#ffff00";
            if (difference > 10 && difference <= 15) cssBg = "#ffa500";
            if (difference > 15 && difference <= 20) cssBg = "#1a9df1";
            if (difference > 20 && difference <= 31) cssBg = "#16a637";

            return cssBg;
        }

        public static int GetGanttChartHeight(int dataRowsCount)
        {
            double height = dataRowsCount > 5 ?  dataRowsCount * 40.0 : 200;

            return (int)height;    
        }

        public static List<GanttChartToolTipViewModel> GetGanttToolTipDetailsLDS(List<ModuleLDSDataViewModel> filteredData)
        {
            var result = new List<GanttChartToolTipViewModel>();

            foreach (var item in filteredData)
            {
                var tooltip = new GanttChartToolTipViewModel
                {
                    Property1 = new KeyVal
                    {
                        ColumnName = "Category",
                        ColumnValue = item.CategoryName
                    },
                    Property2 = new KeyVal
                    {
                        ColumnName = "Content",
                        ColumnValue = item.ContentDescription
                    },
                    Property3 = new KeyVal
                    {
                        ColumnName = "Dates",
                        ColumnValue = $" {item.EffectiveFrom} - {item.EffectiveTo}"
                    },
                    Property4 = new KeyVal
                    {
                        ColumnName = "Timeslots",
                        ColumnValue = $" {item.TimeslotFrom} - {item.TimeslotTo}"
                    },
                };
                result.Add(tooltip);
            }
            return result;
        }

        public static List<GanttChartDataModel> GetGanttChartData(List<ModuleLDSDataViewModel> filteredData)
        {
            var ganttData = new List<GanttChartDataModel>();
            var random = new Random();

            var savedXVals = new List<string>();

            foreach (var data in filteredData)
            {
                var x = SharedFunctions.StringTruncate(data.ContentDescription, 10);

                while (savedXVals.Contains(x))
                    x = $"{SharedFunctions.StringTruncate(data.ContentDescription, 10)}-{random.Next(10)}";

                savedXVals.Add(x);
                
                var gantModel = new GanttChartDataModel
                {
                    x = x,
                    y = new List<long> 
                    { 
                        SharedFunctions.GetTimeInMilliseconds($"{data.EffectiveFrom} {data.TimeslotFrom}"), 
                        SharedFunctions.GetTimeInMilliseconds($"{data.EffectiveTo} {data.TimeslotTo}") 
                    },
                    fillColor = GetGanttBarBackgroundColor(data.EffectiveFrom, data.EffectiveTo)
                };
                ganttData.Add(gantModel);
            }
            return ganttData;
        }
    }
}
