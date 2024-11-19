using CLA_Administration_Web.Models.APIResponses.Reports.Survey;

namespace CLA_Administration_Web.ViewModels.Reports.Survey
{
    public class SurveyReportViewModel
    {
        public int SurveyId { get; set; }

        public SurveyReportSummary SurveySummary { get; set; }

        public List<SurveyReportSummaryDetails> SummarizedDetails { get; set; }

        public SurveyCompleteOptOutViewModel SurveyCompleteOptOut { get; set; }

        public List<SurveyReportSummaryDetails> Outstanding { get; set; }

        public List<SurveyOptInNoResponse> SurveyOptInNoResponseData { get; set; }

        public SurveyOptInNoResponseViewModel SurveyOptInNoResponse { get; set; }

        public List<SurveyLegendTransposed> LegendTransposed { get; set; }

        public List<SurveyUserTransposed> UserTransposed { get; set; }

        public List<SurveyMachineTransposed> MachineTransposed { get; set; }

        public List<SurveyReportAllData> SurveyAllData { get; set; }

    }
}
