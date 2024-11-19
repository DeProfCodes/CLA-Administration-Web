using System.Data;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class ReportDataRDLCViewModel
    {
        public PopupReports PopupReporting { get; set; }

        public TickerReports TickerReporting { get; set; }

        public SurveyReports SurveyReporting { get; set; }

        public PolicyReports PolicyReporting { get; set; }
    }

    public class PopupReports
    {
        public ReportRDLC Summary { get; set; }

        public ReportRDLC Outstanding { get; set; }

        public ReportRDLC QuestionsSummary { get; set; }

        public ReportRDLC ResponseBreakdownData { get; set; }

        public ReportRDLC OutstandingSummary { get; set; }

        public ReportRDLC AllDataOnly { get; set; }

        public ReportRDLC All { get; set; }

        public ReportRDLC Status { get; set; }
    }

    public class TickerReports
    {
        public ReportRDLC Summary { get; set; }

        public ReportRDLC Outstanding { get; set; }

        public ReportRDLC Completed { get; set; }

        public ReportRDLC AllData { get; set; }

        public ReportRDLC Status { get; set; }
    }

    public class SurveyReports
    {
        public ReportRDLC Summary { get; set; }

        public ReportRDLC Details { get; set; }

        public ReportRDLC QuestionsSummary { get; set; }

        public ReportRDLC QuestionsSummaryOptIn { get; set; }

        public ReportRDLC QuestionsDetails { get; set; }

        public ReportRDLC QuestionsDetailsCorrect { get; set; }

        public ReportRDLC QuestionsDetailsIncorrect { get; set; }

        public ReportRDLC QuestionsDetailsOptIn { get; set; }

        public ReportRDLC QuestionsDetailsOptInCorrect { get; set; }

        public ReportRDLC QuestionsDetailsOptInIncorrect { get; set; }

        public ReportRDLC SummaryDetails { get; set; }

        public ReportRDLC Outstanding { get; set; }

        public ReportRDLC OptInNoResponse { get; set; }

        public ReportRDLC OptOut { get; set; }

        public ReportRDLC CompleteAndOptOut { get; set; }

        public ReportRDLC AllData { get; set; }

        public ReportRDLC Status { get; set; }
    }

    public class PolicyReports
    {
        public ReportRDLC Summary { get; set; }

        public ReportRDLC SummaryDetails { get; set; }

        public ReportRDLC Outstanding { get; set; }

        public ReportRDLC ResponseDetails { get; set; }

        public ReportRDLC AllData { get; set; }

        public ReportRDLC Status { get; set; }
    }

    public class CampainDispatchReports
    {
        public string ReportPath { get; set; }

        public ReportRDLC Screensaver { get; set; }

        public ReportRDLC Popup { get; set; }

        public ReportRDLC Survey { get; set; }

        public ReportRDLC Ticker { get; set; }

        public ReportRDLC Lockscreen { get; set; }

        public ReportRDLC Desktop { get; set; }

        public ReportRDLC Params { get; set; }
    }

    public class PopupReportsRaw
    {
        public string Summary { get; set; }

        public string QuestionsSummary { get; set; }

        public string ResponseBreakdownClick { get; set; }

        public string ResponseBreakdownDismiss { get; set; }

        public string ResponseBreakdownAutoHide { get; set; }

        public string ResponseBreakdownSnooze { get; set; }

        public string ResponseBreakdownShow { get; set; }

        public string Outstanding { get; set; }

        public string AllData { get; set; }

    }

    public class SurveyReportsRaw
    {
        public string Summary { get; set; }

        public string Outstanding { get; set; }

        public string OptInNoResponse { get; set; }

        public string OptOut { get; set; }

        public string AllData { get; set; }
    }

    public class TickerReportsRaw
    {
        public string Summary { get; set; }

        public string Outstanding { get; set; }

        public string Completed { get; set; }

        public string AllData { get; set; }
    }

    public class PolicyReportsRaw
    {
        public string Summary { get; set; }

        public string Outstanding { get; set; }

        public string ResponseSummary { get; set; }

        public string AllData { get; set; }
    }

    public class ReportRDLC
    {
        public string ReportRDLCPath { get; set; }

        public string RDLCName { get; set; }

        public DataSet DataSet { get; set; }
    }
}
