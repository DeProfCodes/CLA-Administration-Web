using CLA_Administration_Web.Helpers.Reporting;
using Newtonsoft.Json;
using System.ComponentModel;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Policy
{
    public class PolicyReportSummarizedDetail
    {
        [DisplayName("")]
        [SkipProperty]
        [JsonProperty("TargetedType")]
        public string? TargetedType { get; set; }

        [DisplayName("Summary Info")]
        [JsonProperty("Summary_Info")]
        public string? SummaryInfo { get; set; }

        [DisplayName("Last 30 Days Results")]
        [JsonProperty("Last_30_Days_Result")]
        public int? Last30DaysResult { get; set; }

        [DisplayName("Since Popup Active Results")]
        [JsonProperty("Since_Popup_Active_Result")]
        public int? SincePopupActiveResult { get; set; }
    }
}
