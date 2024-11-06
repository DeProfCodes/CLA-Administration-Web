using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using System.Reflection.Metadata.Ecma335;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ModuleReportResultTitleViewModel
    {
        public ReportsNamesType ReportTypeName { get; set; }

        public string ReportTitle { get; set; }

        public DateTime EffectiveFromDate { get; set; }

        public DateTime EffectiveToDate { get; set; }

        public string OnBackReportTabClickCallbackFunction { get; set; }
    }
}
