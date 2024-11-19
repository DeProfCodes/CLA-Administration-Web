using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.Popup
{
    public class PopupReportQuestionSummary
    {
        [JsonProperty("STM_ID")]
        public int? PopupId { get; set; }

        [JsonProperty("STM_Title")]
        public string? Title { get; set; }

        [JsonProperty("STM_Text")]
        public string? Description { get; set; }

        [JsonProperty("Num_Targeted")]
        public int? NumberTargeted { get; set; }

        [JsonProperty("Perc_Show")]
        public int? PercentageShow { get; set; }

        [JsonProperty("Click")]
        public int? ClickCount { get; set; }

        [JsonProperty("Perc_Click")]
        public int? PercentageClick { get; set; }

        [JsonProperty("Dismiss")]
        public int? DismissCount { get; set; }

        [JsonProperty("Perc_Dismiss")]
        public int? PercentageDismiss { get; set; }

        [JsonProperty("Snooze")]
        public int? SnoozeCount { get; set; }

        [JsonProperty("Perc_Snooze")]
        public int? PercentageSnooze { get; set; }

        [JsonProperty("ReShow")]
        public int? ReShowCount { get; set; }

        [JsonProperty("Perc_ReShow")]
        public int? PercentageReShow { get; set; }

        [JsonProperty("Autohide")]
        public int? AutohideCount { get; set; }

        public int? ShowCount { get; set; }

        [JsonProperty("Perc_Autohide")]
        public int? PercentageAutohide { get; set; }

        [JsonProperty("No_Action")]
        public int? NoActionCount { get; set; }

        [JsonProperty("Perc_No_Action")]
        public int? PercentageNoAction { get; set; }

        [JsonProperty("Eff_From")]
        public DateTime? EffectiveFrom { get; set; }

        [JsonProperty("Eff_To")]
        public DateTime? EffectiveTo { get; set; }
    }
}
