using System.Text.Json.Serialization;

namespace CLA_Administration_Web.ViewModels.API.ResponseModels.Popup
{
    public class ModuleReportListingAPIResponse
    {
        [JsonPropertyName("STM_ID")]
        public string PopupId { get; set; }

        [JsonPropertyName("STM_Header")]
        public string PopupHeader { get; set; }

        [JsonPropertyName("Policy_Title")]
        public string PolicyTitle { get; set; }

        [JsonPropertyName("Ticker_ID")]
        public string TickerId { get; set; }

        [JsonPropertyName("Ticker_Text")]
        public string TickerText { get; set; }

        [JsonPropertyName("Survey_ID")]
        public string SurveyID { get; set; }

        [JsonPropertyName("Survey_Title")]
        public string SurveyTitle { get; set; }
    }
}
