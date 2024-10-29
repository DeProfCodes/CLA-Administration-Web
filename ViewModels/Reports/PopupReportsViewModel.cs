using CLA_Administration_Web.Models.APIResponses.Reports.Popup;
using CLA_Administration_Web.Models.APIResponses.Reports.Ticker;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class PopupReportsViewModel
    {
        public PopupReportSummary PopupReportSummary { get; set; }

        public PopupReportQuestionSummary PopupReportQuestionSummary { get; set; }

        public List<PopupReportResponseDetails> PopupResponseClick { get; set; }

        public List<PopupReportResponseDetails> PopupResponseAutoHide { get; set; }

        public List<PopupReportResponseDetails> PopupResponseSnooze { get; set; }

        public List<PopupReportResponseDetails> PopupResponseDismiss { get; set; }

        public List<PopupReportResponseDetails> PopupResponseShow { get; set; }

        public List<PopupReportOutstanding> PopupReportOutstanding { get; set; }

        public List<PopupReportAllData> PopupReportAllData { get; set; }
    }
}
