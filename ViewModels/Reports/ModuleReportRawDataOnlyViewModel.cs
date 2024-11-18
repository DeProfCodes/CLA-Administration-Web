using CLA_Administration_Web.Models.APIResponses.Reports.Ticker;

namespace CLA_Administration_Web.ViewModels.Reports
{
    public class TickerReportsViewModel
    {
        public int TickerId { get; set; }

        public TickerReportSummary TickerReportSummary { get; set; }

        public List<TickerReportComplete> TickerReportComplete { get; set; }

        public List<TickerReportOutstanding> TickerReportOutstanding { get; set; }

        public List<TickerReportAllData> TickerReportAllData { get; set; }
    }
}
