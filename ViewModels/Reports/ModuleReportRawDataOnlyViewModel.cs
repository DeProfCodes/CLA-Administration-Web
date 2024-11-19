using CLA_Administration_Web.Helpers.Enums.Shared.PageNames;
using CLA_Administration_Web.Models.APIResponses.Reports.Popup;
using CLA_Administration_Web.Models.APIResponses.Reports.Survey;
using CLA_Administration_Web.Models.APIResponses.Reports.Ticker;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ModuleReportRawDataOnlyViewModel
    {
        public ReportsNamesType ReportNameType { get; set; }

        public int ReportModuleId { get; set; }

        public DateTime EffectiveFrom { get; set; }

        public DateTime EffectiveTo { get; set; }

        public List<PopupReportAllData> PopupAllRawData { get; set; }

        public List<TickerReportAllData> TickerAllRawData { get; set; }

        public List<SurveyReportAllData> SurveyAllRawData { get; set; }
    }
}
