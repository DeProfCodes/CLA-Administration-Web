using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportSummary
    {
        [JsonProperty("STM_ID")]
        public int? PopupId { get; set; }

        [JsonProperty("STM_Title")]
        public string? Title { get; set; }

        [JsonProperty("STM_Text")]
        public string? Description { get; set; }

        [JsonProperty("Targeted")]
        public int? Targeted { get; set; }

        [JsonProperty("Show")]
        public int? Show { get; set; }

        [JsonProperty("Completed")]
        public int? Completed { get; set; }

        [JsonProperty("Outstanding")]
        public int? Outstanding { get; set; }

        [JsonProperty("Eff_From")]
        public DateTime? EffectiveFrom { get; set; }

        [JsonProperty("Eff_To")]
        public DateTime? EffectiveTo { get; set; }
    }
}
