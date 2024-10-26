using CLA_Administration_Web.Helpers.Enums.AppPages;
using CLA_Administration_Web.Helpers.Enums.Shared;

namespace CLA_Administration_Web.Helpers.Html
{
    public class CssHtmlHelpers
    {
        public const string CSS_INVISIBLE = "invisible";

        public const string CSS_HIDDEN = "hidden";

        public static string GetBGForYesNoValues(string yesNo)
        {
            yesNo = yesNo.ToLower();

            if (yesNo == "yes") return "bg-success";
            if (yesNo == "no") return "bg-danger";

            return "bg-secondary";
        }

        public static string GetReportRowStatusColor(DateTime lastSyncDate)
        {
            DateTime currentDate = DateTime.Now;
            DateTime thirtyDaysAgo = currentDate.AddDays(-30);
            DateTime minDate = new DateTime(1900, 1, 1);

            if (lastSyncDate >= thirtyDaysAgo) return "bg-success";
            if (lastSyncDate > minDate.AddDays(-30)) return "bg-warning";
            
            return "report-piechart-color-red-mid";
        }
    }
}
