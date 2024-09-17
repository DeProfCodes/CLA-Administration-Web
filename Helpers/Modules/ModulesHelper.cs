using CLA_Administration_Web.Helpers.Enums.Shared;
using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.ViewModels.Modules;
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

        public static string GetPopupOverviewText(string status, string user, string startDate, string endDate)
        {
            var filterTitle = $"Showing {status.ToUpper()}";
            filterTitle += " for " + (user == "all" ? "ALL Users" : user);
            filterTitle += $" from {startDate} to {endDate}";

            return filterTitle;
        }

        public static List<PopupViewModel> FilterPopupsData(List<PopupViewModel> data, string status, string user, string startDate, string endDate)
        {
            var startDateTime = TypesParserHelper.ParseDate(startDate);
            var endDateTime = TypesParserHelper.ParseDate(endDate);
            
            status = status.ToLower();
            user = user.ToLower();

            var filteredData = data.Where(
                                            p => ((status != "all" && status != "") ? (p.Status.StatusType.GetDisplayName().ToLower() == status) : true) &&
                                                 (startDateTime.Date.CompareTo(p.EffectiveFromDate) <= 0 && p.EffectiveToDate.Date.CompareTo(endDateTime) <= 0) &&
                                                 (user != "all" ? (p.UserIdLastModified == user) : true)
                                    ).ToList();

            return filteredData;
        }
    }
}
