using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Survey
{
    public class SurveyReportSummary
    {
        [JsonProperty("Survey_Title")]
        public string? SurveyTitle { get; set; }

        [JsonProperty("Eff_From")]
        public DateTime? EffFrom { get; set; }

        [JsonProperty("Eff_To")]
        public DateTime? EffTo { get; set; }

        [JsonProperty("Survey_ID")]
        public int? SurveyId { get; set; }

        [JsonProperty("Targeted")]
        public int? Targeted { get; set; }

        [JsonProperty("Opt_In")]
        public int? OptIn { get; set; }

        [JsonProperty("Complete")]
        public int? Complete { get; set; }

        [JsonProperty("Outstanding")]
        public int? Outstanding { get; set; }

        [JsonProperty("Average_Duration_Seconds")]
        public int? AverageDurationSeconds { get; set; }
    }
}
