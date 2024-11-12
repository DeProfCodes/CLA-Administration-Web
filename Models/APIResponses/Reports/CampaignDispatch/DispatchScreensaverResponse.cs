using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchScreensaverResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("Screen_User_Last_Modified")]
        public string? ScreenUserLastModified { get; set; }

        [JsonProperty("Screen_Eff_From")]
        public DateTime? ScreenEffFrom { get; set; }

        [JsonProperty("Screen_Eff_To")]
        public DateTime? ScreenEffTo { get; set; }

        [JsonProperty("Screen_Timeslot_From")]
        public string? ScreenTimeslotFrom { get; set; }

        [JsonProperty("Screen_Timeslot_To")]
        public string? ScreenTimeslotTo { get; set; }

        [JsonProperty("Screen_Is_Automated")]
        public int? ScreenIsAutomated { get; set; }

        [JsonProperty("Screen_Advert_Description")]
        public string? ScreenAdvertDescription { get; set; }

        [JsonProperty("Screen_Advert_ID")]
        public int? ScreenAdvertId { get; set; }

        [JsonProperty("Screensaver_Description")]
        public string? ScreensaverDescription { get; set; }

        [JsonProperty("Screen_Sequence_Header_ID")]
        public int? ScreenSequenceHeaderId { get; set; }

        [JsonProperty("Screen_Sequence_Position")]
        public int? ScreenSequencePosition { get; set; }

        [JsonProperty("Screen_Impression_Duration")]
        public int? ScreenImpressionDuration { get; set; }

        [JsonProperty("Screen_Transition_ID")]
        public int? ScreenTransitionId { get; set; }
    }
}
