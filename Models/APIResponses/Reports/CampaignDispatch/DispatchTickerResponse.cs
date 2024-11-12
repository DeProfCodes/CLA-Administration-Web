using Newtonsoft.Json;

namespace CLA_Administration_Web.Models.APIResponses.Reports.CampaignDispatch
{
    public class DispatchTickerResponse
    {
        [JsonProperty("Environment")]
        public string? Environment { get; set; }

        [JsonProperty("Targeted")]
        public string? Targeted { get; set; }

        [JsonProperty("Ticker_User_Last_Modified")]
        public string? TickerUserLastModified { get; set; }

        [JsonProperty("Ticker_Eff_From")]
        public DateTime? TickerEffFrom { get; set; }

        [JsonProperty("Ticker_Eff_To")]
        public DateTime? TickerEffTo { get; set; }

        [JsonProperty("Ticker_Timeslot_From")]
        public string? TickerTimeslotFrom { get; set; }

        [JsonProperty("Ticker_Timeslot_To")]
        public string? TickerTimeslotTo { get; set; }

        [JsonProperty("Ticker_Is_Automated")]
        public int? TickerIsAutomated { get; set; }

        [JsonProperty("Ticker_Provider_ID")]
        public int? TickerProviderId { get; set; }

        [JsonProperty("Ticker_Has_Linked_Blob")]
        public int? TickerHasLinkedBlob { get; set; }

        [JsonProperty("Ticker_Linked_Blob_FileName")]
        public string? TickerLinkedBlobFileName { get; set; }

        [JsonProperty("Ticker_Linked_Blob_Length")]
        public int? TickerLinkedBlobLength { get; set; }

        [JsonProperty("Ticker_Has_Linked_URL")]
        public int? TickerHasLinkedUrl { get; set; }

        [JsonProperty("Ticker_Linked_URL")]
        public string? TickerLinkedUrl { get; set; }

        [JsonProperty("Ticker_Has_Linked_Survey")]
        public int? TickerHasLinkedSurvey { get; set; }

        [JsonProperty("Ticker_Linked_Survey_ID")]
        public int? TickerLinkedSurveyId { get; set; }

        [JsonProperty("Ticker_Ticker_ID")]
        public int? TickerTickerId { get; set; }

        [JsonProperty("Ticker_Ticker_Text")]
        public string? TickerTickerText { get; set; }

        [JsonProperty("Ticker_Ticker_LinkType")]
        public int? TickerTickerLinkType { get; set; }
    }
}
